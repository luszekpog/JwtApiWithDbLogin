using CryptoAPI.Modules;
using CryptoAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoRepository _cryptorepository;

        public CryptoController(ICryptoRepository cryptorepository)
        {
            _cryptorepository = cryptorepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Crypto>> GetCrypto(int id)
        {
            return await _cryptorepository.Get(id);
        }
        [HttpGet]
        public async Task<IEnumerable<Crypto>> GetCryptos()
        {
            return await _cryptorepository.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Crypto>> PostCrypto([FromBody] Crypto crypto)
        {
            var newCrypto = await _cryptorepository.Create(crypto);
            return CreatedAtAction(nameof(GetCrypto), new { id = newCrypto.Id }, newCrypto);
        }
        [HttpPut]
        public async Task<ActionResult<Crypto>> PutCrypto(int id, [FromBody] Crypto crypto)
        {
            if (id != crypto.Id)
            {
                return BadRequest();
            }
            await _cryptorepository.Update(crypto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCrypto(int id)
        {
            var bookToDelete = await _cryptorepository.Get(id);
            if (bookToDelete == null)
                return NotFound();

            await _cryptorepository.Delete(bookToDelete.Id);
            return NoContent();
        }
        [HttpGet]
        public async Task<List<CryptoWithoutPrice>> GetWithoutPrice()
            {
            return await _cryptorepository.GetWithoutPrices();
            }
   
    }
   
}
