using ISO.Server.DTO;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Currency> GetCurrencyByCode(string code)
            => await Task.Run(() => currencyTable.CcyNtry.FirstOrDefault(c => c.CcyNbr == code));

        public async Task<Currency> GetCurrencyBySimbol(string symbol)
            => await Task.Run(() => currencyTable.CcyNtry.FirstOrDefault(c => c.Ccy == symbol));

        public async Task<IEnumerable<Currency>> GetCurrensies()
            => await Task.Run(() => currencyTable.CcyNtry);

        public async Task<IEnumerable<MerchantCategory>> GetMerchantCategories()
            => await Task.Run(() => mccTable.MccNtry);

        public async Task<MerchantCategory> GetMerchantCategoryById(int id)
            => await Task.Run(() => mccTable.MccNtry.FirstOrDefault(m => m.Id == id));

        public async Task<MerchantCategory> GetMerchantCategoryByCode(string code)
            => await Task.Run(() => mccTable.MccNtry.FirstOrDefault(m => m.Mcc == code));
    }
}
