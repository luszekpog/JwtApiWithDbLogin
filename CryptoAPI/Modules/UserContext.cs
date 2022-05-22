using Microsoft.EntityFrameworkCore;

namespace CryptoAPI.Modules
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
        DbSet<User> Users { get; set; }

    }
}
