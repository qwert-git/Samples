using System.Threading.Tasks;

namespace Auth.API.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string username, string password);
    }
}