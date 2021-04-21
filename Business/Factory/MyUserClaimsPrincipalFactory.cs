using System.Security.Claims;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Business.Factory
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        public MyUserClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Firstname", user.Name));
            identity.AddClaim(new Claim("Surname", user.Surname));
            identity.AddClaim(new Claim("Email", user.Email));
            identity.AddClaim(new Claim("UserId", user.Id.ToString()));
            return identity;
        }
    }
}