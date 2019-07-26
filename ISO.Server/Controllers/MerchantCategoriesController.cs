using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ISO.Server.Services;
using ISO.Server.DTO;

namespace ISO.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantCategoriesController : ControllerBase
    {
        private readonly IIsoService _isoService;

        public MerchantCategoriesController(IIsoService isoService)
            => _isoService = isoService;
        
        [HttpGet]
        public ActionResult<IEnumerable<MerchantCategory>> Get()
        {
            return Ok(_isoService.GetMerchantCategories());
        }

        [HttpGet("{code}", Name = "Get")]
        public ActionResult<MerchantCategory> Get(string code)
        {
            var mcc = _isoService.MerchantCategoryByCode(code);
            if (mcc != null) return Ok(mcc);
            else return NotFound(new Error { Description = "No category matching this ID" });
        }
    }
}
