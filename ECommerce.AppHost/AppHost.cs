var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");


//builder.AddProject<Projects.ECommerce_Web>("webfrontend")
//    .WithExternalHttpEndpoints()
//    .WithHttpHealthCheck("/health")
//    .WithReference(cache)
//    .WaitFor(cache)
//    .WithReference(apiService)
//    .WaitFor(apiService);

builder.AddProject<Projects.ECommerce_API>("ecommerce-api").WithHttpHealthCheck("/health");

builder.Build().Run();
