using System.Threading.Tasks;
using Entities.DTO.Auth;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterDto register);
    }
}