using System.Collections.Generic;
using ISO.Server.DTO;

namespace ISO.Server.Services
{
    public interface IIsoService
    {
        ICollection<Currency> GetCurrensies();
        Currency GetCurrencyByCode(string code);
        Currency GetCurrencyBySimbol(string symbol);

        ICollection<MerchantCategory> GetMerchantCategories();
        MerchantCategory MerchantCategoryByCode(string code);
        MerchantCategory GetMerchantCategoryById(int id);
    }
}
