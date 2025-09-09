using Microsoft.AspNetCore.Identity;

namespace My_new_API.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        public string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
