using KontaktyBlazor.Client.DTO.AuthDTO;
namespace KontaktyBlazor.Client.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
