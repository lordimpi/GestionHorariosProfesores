using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace MiniSIMCA.Helpers
{
    public interface IUserHelperDA
    {
        Task<User> GetUserAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);

    }
}