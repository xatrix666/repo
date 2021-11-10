namespace Asteroids.Domain.Models
{
    public class AuthenticateResponseModel
    {
        public bool Login { get; set; }
        public string Token { get; set; }
    }
}
