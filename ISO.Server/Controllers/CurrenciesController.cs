using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISO.Server.Services;
using ISO.Server.DTO;

namespace ISO.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly IIsoService _isoService;

        public CurrenciesController(IIsoService isoService)
            => _isoService = isoService;
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> Get()
            => Ok(await _isoService.GetCurrensies());
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> Get(string id)
        {
            var answ = await CheckInput(id);
            if (answ != null) return Ok(answ);
            else return NotFound(new Error { Description = "No currency matching this ID" });
        }

        private async Task<Currency> CheckInput(string input)
        {
            var cbc = await _isoService.GetCurrencyByCode(input);
            if (cbc == null) return await _isoService.GetCurrencyBySimbol(input.ToUpper());
            else return cbc;
        }
    }
}
