using System.Threading.Tasks;
using Auth.API.Models;

namespace Auth.API.Services.RoleManager
{
    public interface IRoleManager
    {
        Task<AppRole> GetUserRoleAsync(string username);
    }
}