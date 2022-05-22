using Microsoft.EntityFrameworkCore;

namespace CryptoAPI.Modules
{
    [Keyless]
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAdress { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }

    }
}
