using ISO.Server.DTO;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace ISO.Server.Services.Implements
{
    public class IsoService : IIsoService
    {
        private readonly CurrencyTable currencyTable;
        private readonly MccTable mccTable;

        public IsoService(IOptions<DTO.ISO> isoOptions)
        {
            currencyTable = isoOptions.Value.ISO_4217.CcyTbl;
            mccTable = isoOptions.Value.ISO_18245.MccTbl;
        }

        public Currency GetCurrencyByCode(string code)
            => currencyTable.CcyNtry.FirstOrDefault(c => c.CcyNbr == code);

        public Currency GetCurrencyBySimbol(string symbol)
            => currencyTable.CcyNtry.FirstOrDefault(c => c.Ccy == symbol);

        public ICollection<Currency> GetCurrensies()
            => currencyTable.CcyNtry;

        public ICollection<MerchantCategory> GetMerchantCategories()
            => mccTable.MccNtry;

        public MerchantCategory GetMerchantCategoryById(int id)
            => mccTable.MccNtry.FirstOrDefault(m => m.Id == id);

        public MerchantCategory MerchantCategoryByCode(string code)
            => mccTable.MccNtry.FirstOrDefault(m => m.Mcc == code);
    }
}
