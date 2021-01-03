using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.API.Helpers;
using Auth.API.Models;

namespace Auth.API.Services.RoleManager
{
    public class RoleManager : IRoleManager
    {
        private static Dictionary<string, AppRole> _userRoleStorage = new Dictionary<string, AppRole>
        {
            { "user1", new AppRole{ Name = RoleName.User }},
            { "user2", new AppRole{ Name = RoleName.User }},
            { "user3", new AppRole{ Name = RoleName.User }}
        };

        public Task<AppRole> GetUserRoleAsync(string username)
        {
            var result = _userRoleStorage.TryGetValue(username, out AppRole role) ? role : null;
            return Task.FromResult(result);
        }
    }
}