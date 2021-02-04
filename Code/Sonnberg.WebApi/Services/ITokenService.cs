using Sonnberg.Persistance.Entities;

namespace Sonnberg.WebApi.Services
{
    public interface ITokenService
    {
        string CreateToken(SonnUser user);
    }
}
