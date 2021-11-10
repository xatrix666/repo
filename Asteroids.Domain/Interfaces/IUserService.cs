using Asteroids.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids.Domain.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponseModel Authenticate(AuthenticateRequestModel model, string secret);
    }
}
