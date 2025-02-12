using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Auth;
using Entities.DTO.Profile;
using Microsoft.AspNetCore.Http;
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

        public async Task<DataResult<AppUser>> UserIsExist(string userName)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return new SuccessDataResult<AppUser>(user);
            }
            return new ErrorDataResult<AppUser>("Böyle bir kullanıcı bulunamadı !");
        }

        public async Task<Result> FailedLogin(AppUser user)
        {
            await _userManager.AccessFailedAsync(user);

            int failCount = await _userManager.GetAccessFailedCountAsync(user);
            if (failCount == 5)
            {
                await _userManager.SetLockoutEndDateAsync(user, new System.DateTimeOffset(DateTime.Now.AddMinutes(30)));
                return new ErrorResult("Art arda 5 başarısız giriş yaptığınız için hesabınız 30 dakika askıya alınmıştır !");
            }
            return new SuccessResult();
        }

        public async Task ResetFailedCount(AppUser user)
        {
            await _userManager.ResetAccessFailedCountAsync(user);
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
            await _userManager.AddToRoleAsync(user, "User");
            return result;
        }

        public async Task<AppUser> GetUserAsync(string userName)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<List<string>> GetUserRolesAsync(AppUser user) => await _userManager.GetRolesAsync(user) as List<string>;

    }
}