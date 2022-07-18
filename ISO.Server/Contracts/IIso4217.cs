using ISO.Server.Models.Dto;

namespace ISO.Server.Contracts;

public interface IIso4217
{
    Task<IEnumerable<Currency>> GetCurrensiesAsync();
    Task<Currency> GetCurrencyByCodeAsync(string code);
    Task<Currency> GetCurrencyBySimbolAsync(string symbol);
}
