using ISO.Server.Contracts;
using ISO.Server.Models.Dto;
using Microsoft.Extensions.Options;

namespace ISO.Server.Services;

public class Iso18245Service : IIso18245
{
    private readonly Iso18245 _iso18245;

    public Iso18245Service(IOptions<Models.Dto.Iso> isoOpt)
    {
        _iso18245 = isoOpt.Value.Iso18245 ?? throw new ArgumentNullException(
            $"{nameof(isoOpt)} value.{nameof(isoOpt.Value.Iso18245)} value is null");
    }

    public Task<IEnumerable<MerchantCategory>> GetMerchantCategoriesAsync()
        => Task.Run(() => _iso18245.MerchantEntries ?? new List<MerchantCategory>());

    public Task<MerchantCategory> GetMerchantCategoryByCodeAsync(string code)
        => Task.Run(() => _iso18245.MerchantEntries?.FirstOrDefault(c
            => c.MerchantCategoryCode == code) ?? new DefaultMerchantCategory());
}
