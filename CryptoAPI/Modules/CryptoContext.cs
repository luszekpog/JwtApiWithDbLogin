using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CryptoAPI.Modules
{
    public class CryptoContext : DbContext
    {
        public CryptoContext(DbContextOptions<CryptoContext> options)
            : base(options)
        {

        }
        public DbSet<Crypto> Cryptocurrencies { get; set; }

    }
}
