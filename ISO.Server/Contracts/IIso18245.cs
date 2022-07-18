using ISO.Server.Models.Dto;

namespace ISO.Server.Contracts;

public interface IIso18245
{
    Task<IEnumerable<MerchantCategory>> GetMerchantCategoriesAsync();
    Task<MerchantCategory> GetMerchantCategoryByCodeAsync(string code);
}
