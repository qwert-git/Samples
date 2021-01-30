using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.API.Models;

namespace Auth.API.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private static List<AppUser> Users = new List<AppUser>
        {
            new AppUser { UserName = "user1", Password = "pswrd1" },
            new AppUser { UserName = "user2", Password = "pswrd2" },
            new AppUser { UserName = "user3", Password = "pswrd3" }
        };

        public Task<bool> AuthenticateAsync(string username, string password)
        {
            return Task.FromResult(Users.Any(u => u.UserName == username && u.Password == password));
        }
    }
}