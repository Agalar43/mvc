using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
           
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
                throw new Exception("User could not be created.");

            if (userDto.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with roles.");
            }

            return result;
        }

        public async Task<IdentityResult> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user is not null)
            {
                var result = await _userManager.DeleteAsync(user);
                
                return result;
            }
            else
            {
                throw new Exception("system hava problem");
            }
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto passwordDto, string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user is not null)
            {
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, passwordDto.Password);
                return result;
            }
            else
            {
                throw new Exception("User could not be found");
            }
        }

        public async Task Update(userDtoForUpdate userDto, string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user is not null)
            {
                user.Email = userDto.Email;
                user.PhoneNumber = userDto.PhoneNumber;
                user.UserName = userDto.Username;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                }
                else
                {
                    throw new Exception("System have a problem");
                }
            }
            else
            {
                throw new Exception("System have a problem");
            }
            return;
        }
    }
}