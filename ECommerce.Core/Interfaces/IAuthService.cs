using ECommerce.Core.ViewModels;


namespace ECommerce.Core.Interfaces
{
    public interface IAuthService
    {
        public ValueTask<string> CreateUser(SignUpViewModel signUpVM);
        public ValueTask<string> UpdateUser(SignUpViewModel signUpVM);
        public ValueTask<string> ValidateCredential(SignInViewModel signInVM);
    }
}
