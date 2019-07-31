using System.Collections.Generic;
using System.Threading.Tasks;
using ISO.Server.DTO;

namespace ISO.Server.Services
{
    public interface IIsoService
    {
        Task<IEnumerable<Currency>> GetCurrensies();
        Task<Currency> GetCurrencyByCode(string code);
        Task<Currency> GetCurrencyBySimbol(string smbol);

        Task<IEnumerable<MerchantCategory>> GetMerchantCategories();
        Task<MerchantCategory> GetMerchantCategoryByCode(string code);
        Task<MerchantCategory> GetMerchantCategoryById(int id);
    }
}
