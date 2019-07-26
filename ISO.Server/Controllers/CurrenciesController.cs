using System.Collections.Generic;
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
        public ActionResult<IEnumerable<Currency>> Get()
        {
            return Ok(_isoService.GetCurrensies());
        }
        
        [HttpGet("{id}")]
        public ActionResult<Currency> Get(string id)
        {
            var answ = CheckInput(id);
            if (answ != null) return Ok(answ);
            else return NotFound(new Error { Description = "No currency matching this ID" });
        }

        private Currency CheckInput(string input)
        {
            var cbc = _isoService.GetCurrencyByCode(input);
            if (cbc == null) return _isoService.GetCurrencyBySimbol(input.ToUpper());
            else return cbc;
        }
    }
}
