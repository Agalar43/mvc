using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();

        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task<IdentityResult> ResetPassword(ResetPasswordDto passwordDto, string Id);
        Task<IdentityResult> DeleteUser(string Id);
        Task Update(userDtoForUpdate userDto, string id);


    }
}