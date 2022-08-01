using ISO.Server.Contracts;
using ISO.Server.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ISO.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class MerchantCategoriesController : ControllerBase
{
    // https://static.sovest.com/mcc-codes.pdf
    // https://mcc-codes.ru/code

    private readonly IIso18245 _iso18245;

    public MerchantCategoriesController(IIso18245 iso18245)
    {
        _iso18245 = iso18245;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MerchantCategory>>> GetAsync()
    {
        try
        {
            return Ok(await _iso18245.GetMerchantCategoriesAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

      [HttpGet("{code}")]
        public async Task<ActionResult<MerchantCategory>> GetAsync(string code)
        {
            try
            {
                var result = await _iso18245.GetMerchantCategoryByCodeAsync(code);

                if (result.GetType() == typeof(DefaultMerchantCategory))
                {
                    return NotFound(((DefaultMerchantCategory)result).NotFoundCategory(code));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
