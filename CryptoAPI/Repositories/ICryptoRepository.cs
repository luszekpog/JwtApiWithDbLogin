using CryptoAPI.Modules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoAPI.Repositories
{
    public interface ICryptoRepository 
    {
        Task<IEnumerable<Crypto>> Get();
        Task<Crypto> Get(int id);
        Task<Crypto> Create(Crypto crypto);
        Task Update(Crypto crypto);
        Task Delete(int id);
        Task<List<CryptoWithoutPrice>> GetWithoutPrices();
    }

}
