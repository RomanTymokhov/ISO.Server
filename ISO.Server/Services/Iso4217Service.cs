using ISO.Server.Contracts;
using ISO.Server.Models.Dto;
using Microsoft.Extensions.Options;

namespace ISO.Server.Services;

public class Iso4217Service : IIso4217
{
    private readonly Iso4217 _iso4217;

    public Iso4217Service(IOptions<Models.Dto.Iso> isoOpt)
    {
        _iso4217 = isoOpt.Value.Iso4217 ?? throw new ArgumentNullException(
            $"{nameof(isoOpt)} value.{nameof(isoOpt.Value.Iso4217)} value is null");
    }

    public Task<Currency> GetCurrencyByCodeAsync(string code)
        => Task.Run(() => _iso4217.CurrencyEntries?.FirstOrDefault(c
            => c.CurrencyCode?.ToLower() == code.ToLower()) ?? new DefaultCurrency());

    public Task<Currency> GetCurrencyBySimbolAsync(string symbol)
        => Task.Run(() => _iso4217.CurrencyEntries?.FirstOrDefault(c
            => c.CurrencySymbol?.ToLower() == symbol.ToLower()) ?? new DefaultCurrency());

    public Task<IEnumerable<Currency>> GetCurrensiesAsync()
        => Task.Run(() => _iso4217.CurrencyEntries ?? new List<Currency>());
}
