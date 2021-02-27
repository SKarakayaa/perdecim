using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTO.Auth;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        public AuthManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IdentityResult> Register(RegisterDto register)
        {
            AppUser user = new AppUser
            {
                UserName = register.UserName,
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber
            };
            IdentityResult result = await _userManager.CreateAsync(user, register.Password);
            return result;
        }
    }
}