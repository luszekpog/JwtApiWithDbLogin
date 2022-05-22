using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CryptoAPI.Modules
{
    public class UserConstants : DbContext
    {
        public UserConstants(DbContextOptions<UserConstants> options)
             : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }


    } 
}
