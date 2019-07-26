using System.Collections.Generic;
using ISO.Server.DTO;

namespace ISO.Server.Services
{
    public interface IIsoService
    {
        IEnumerable<Currency> GetCurrensies();
        Currency GetCurrencyByCode(string code);
        Currency GetCurrencyBySimbol(string smbol);

        IEnumerable<MerchantCategory> GetMerchantCategories();
        MerchantCategory GetMerchantCategoryByCode(string code);
        MerchantCategory GetMerchantCategoryById(int id);
    }
}
