﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids.Domain.Models
{
    public class AuthenticateRequestModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
