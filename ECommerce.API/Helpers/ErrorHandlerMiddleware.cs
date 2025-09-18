using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

namespace ECommerce.API.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestBody = await ReadRequestBodyAsync(context);

            try
            {
                await _next(context);

                // Automatic DataAnnotations/ModelState validation capture
                if (!context.Response.HasStarted && context.Items.ContainsKey("ModelStateErrors"))
                {
                    var errors = context.Items["ModelStateErrors"] as string[];
                    if (errors != null && errors.Length > 0)
                    {
                        await WriteResponse(context, 400, "Validation Failed", JsonSerializer.Serialize(errors), requestBody);
                    }
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, requestBody);
            }
        }

        private async Task<string> ReadRequestBodyAsync(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, leaveOpen: true);
                var body = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0; // reset for next middleware
                return body.Length > 5000 ? body.Substring(0, 5000) + "..." : body; // truncate large payloads
            }
            catch
            {
                return "[Unable to read request body]";
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, string payload)
        {
            var moduleName = ex.TargetSite?.DeclaringType?.FullName ?? "UnknownModule";
            var stackTrace = _env.IsDevelopment() ? ex.StackTrace : null;

            string? controller = context.GetRouteValue("controller")?.ToString();
            string? action = context.GetRouteValue("action")?.ToString();

            _logger.LogError(ex, "Exception in {Module}, Controller: {Controller}, Action: {Action}, Path: {Path}", moduleName, controller, action, context.Request.Path);

            var (statusCode, customCode) = MapExceptionToStatusCode(ex);

            var problem = new ResponseViewModel
            {
                status = statusCode,
                message = ex.Message,
                detail = ex.InnerException?.Message ?? stackTrace,
                instance = context.Request.Path,
                module = moduleName,
                controller = controller,
                action = action,
                payload = payload,
                customCode = customCode
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }

        private (int httpStatus, int? customCode) MapExceptionToStatusCode(Exception ex)
        {
            return ex switch
            {
                ValidationException => (400, null),
                ArgumentNullException => (400, null),
                ArgumentException => (400, null),
                KeyNotFoundException => (404, null),
                NullReferenceException => (404, null),
                UnauthorizedAccessException => (401, null),
                DbUpdateException dbEx => HandleDbUpdateException(dbEx),
                TimeoutException => (408, null),
                NotImplementedException => (501, 1000),
                NotSupportedException => (405, null),
                JsonException => (415, null),
                InvalidCastException => (400, 618),
                _ => (500, 999)
            };
        }

        private (int, int?) HandleDbUpdateException(DbUpdateException dbEx)
        {
            if (dbEx.InnerException is SqlException sqlEx)
            {
                return sqlEx.Number switch
                {
                    515 => (400, 515),
                    547 => (409, 547),
                    2601 => (409, 2601),
                    8152 => (400, 8152),
                    _ => (500, sqlEx.Number)
                };
            }
            return (500, null);
        }

        private async Task WriteResponse(HttpContext context, int status, string message, string? detail = null, string? payload = null)
        {
            var problem = new ResponseViewModel
            {
                status = status,
                message = message,
                detail = detail,
                instance = context.Request.Path,
                payload = payload,
                timestamp = DateTime.UtcNow
            };

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }

    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }

    public class ResponseViewModel
    {
        public int status { get; set; }
        public string message { get; set; } = string.Empty;
        public string? detail { get; set; }
        public string instance { get; set; } = string.Empty;
        public string? module { get; set; }
        public string? controller { get; set; }
        public string? action { get; set; }
        public string? payload { get; set; }
        public int? customCode { get; set; }
        public DateTime timestamp { get; set; } = DateTime.UtcNow;
    }

    // ModelState validation capture helper
    internal class ModelStateFeatureWrapper : IModelStateFeature
    {
        private readonly HttpContext _context;
        public ModelStateFeatureWrapper(HttpContext context) => _context = context;

        public ModelStateDictionary ModelState
        {
            get
            {
                if (_context.Items.TryGetValue("ModelStateErrors", out var val))
                    return val as ModelStateDictionary ?? new ModelStateDictionary();
                return new ModelStateDictionary();
            }
            set
            {
                if (!value.IsValid)
                {
                    var errors = value
                        .SelectMany(ms => ms.Value.Errors.Select(e => $"{ms.Key}: {e.ErrorMessage}"))
                        .ToArray();
                    _context.Items["ModelStateErrors"] = errors;
                }
            }
        }
    }
}
