using CryptoAPI.Modules;
using System.Threading.Tasks;

namespace CryptoAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
    }
}
