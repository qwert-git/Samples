using System.Security.Claims;

namespace Auth.API.Services.AuthTokenIssuer
{
    public interface IAuthTokenIssuer
    {
        string GetAccessToken(Claim[] claims);
    }
}