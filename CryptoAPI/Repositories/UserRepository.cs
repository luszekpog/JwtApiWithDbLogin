using CryptoAPI.Modules;
using System.Threading.Tasks;

namespace CryptoAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserConstants _context;

        public UserRepository(UserConstants context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            _context.UsersTable.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
