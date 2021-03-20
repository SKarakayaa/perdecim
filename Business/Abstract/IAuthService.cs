using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Auth;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterDto register);
        Task<AppUser> GetUserAsync(string userName);
        Task<List<string>> GetUserRolesAsync(AppUser user);
        Task<DataResult<AppUser>> UserIsExist(string userName);
        Task<Result> FailedLogin(AppUser user);
        Task ResetFailedCount(AppUser user);
    }
}