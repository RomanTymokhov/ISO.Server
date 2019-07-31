using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISO.Server.Services;
using ISO.Server.DTO;

namespace ISO.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantCategoriesController : ControllerBase
    {
        // https://static.sovest.com/mcc-codes.pdf
        // https://mcc-codes.ru/code

        private readonly IIsoService _isoService;

        public MerchantCategoriesController(IIsoService isoService)
            => _isoService = isoService;
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MerchantCategory>>> Get()
            => Ok(await _isoService.GetMerchantCategories());

        [HttpGet("{code}")]
        public async Task<ActionResult<MerchantCategory>> Get(string code)
        {
            var mcc = await _isoService.GetMerchantCategoryByCode(code);
            if (mcc != null) return Ok(mcc);
            else return NotFound(new Error { Description = "No category matching this ID" });
        }
    }
}
