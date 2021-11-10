using Asteroids.Domain.Models;

namespace Asteroids.Domain.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponseModel Authenticate(AuthenticateRequestModel model, string secret);
    }
}
