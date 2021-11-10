using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteroids.Application.DTOs
{
    public class AuthenticateResponseDto
    {
        public bool Login { get; set; }
        public string Token { get; set; }
    }
}
