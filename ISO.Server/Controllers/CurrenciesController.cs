using ISO.Server.Contracts;
using ISO.Server.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ISO.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    private readonly IIso4217 _iso4217;

    public CurrenciesController(IIso4217 iso4217)
    {
        _iso4217 = iso4217;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Currency>>> GetAsync()
    {
        try
        {
            return Ok(await _iso4217.GetCurrensiesAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("code/{code}")]
    public async Task<ActionResult<Currency>> GetByCodeAsync(string code)
    {
            try
            {
                var result = await _iso4217.GetCurrencyByCodeAsync(code);

                if (result.GetType() == typeof(DefaultCurrency))
                {
                    return NotFound(((DefaultCurrency)result).NotFoundCode(code));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
    }

    [HttpGet("symbol/{symbol}")]
    public async Task<ActionResult<Currency>> GetBySymbolAsync(string symbol)
    {
            try 
            {
                var result = await _iso4217.GetCurrencyBySimbolAsync(symbol);

                if (result.GetType() == typeof(DefaultCurrency))
                {
                    return NotFound(((DefaultCurrency)result).NotFoundSymbol(symbol));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
    }
}
