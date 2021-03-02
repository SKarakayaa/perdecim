namespace Entities.DTO.Auth
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Persistent { get; set; }
        public bool Lock { get; set; }
    }
}