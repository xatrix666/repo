using Asteroids.Domain.Implementations;
using Asteroids.Domain.Models;
using System;
using Xunit;

namespace Asteroids.Tests
{
    public class AuthenticateTest
    {
        [Fact]
        public void ResultAuth_CorrectData_ShouldBeTrue()
        {
            AuthenticateRequestModel authenticateRequestExpected = new AuthenticateRequestModel()
            {
                Username = "Client@test.com",
                Password = "Client@1234"
            };
            var secret = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE2MzY0ODU3MjEsImV4cCI6MTY2ODAyMTcyMSwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.YPd_9DYBcqIN_MWYaEKCrgtsimdZX5FJI5WNCQaGQ40";

            UserService service = new UserService();
            var authenticateResponse = service.Authenticate(authenticateRequestExpected, secret);

            Assert.NotNull(authenticateRequestExpected.Username);
            Assert.NotNull(authenticateRequestExpected.Password);
            Assert.NotNull(authenticateResponse.Token);
            Assert.True(authenticateResponse.Login);
            Assert.NotEqual(authenticateResponse.Token, secret);
        }

        [Fact]
        public void ResultAuth_BadData_ShouldBeFalse()
        {
            AuthenticateRequestModel authenticateRequestExpected = new AuthenticateRequestModel()
            {
                Username = "Arwen@test.com",
                Password = "Arwen@1234"
            };
            var secret = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE2MzY0ODU3MjEsImV4cCI6MTY2ODAyMTcyMSwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.YPd_9DYBcqIN_MWYaEKCrgtsimdZX5FJI5WNCQaGQ40";

            UserService service = new UserService();
            var authenticateResponse = service.Authenticate(authenticateRequestExpected, secret);

            Assert.NotNull(authenticateRequestExpected.Username);
            Assert.NotNull(authenticateRequestExpected.Password);
            Assert.Null(authenticateResponse);
        }
    }
}
