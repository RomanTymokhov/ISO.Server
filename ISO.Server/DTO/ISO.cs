using Newtonsoft.Json;
using System.Collections.Generic;

namespace ISO.Server.DTO
{
    public class ISO
    {
        [JsonProperty("ISO_4217")]
        public ISO_4217 ISO_4217 { get; set; }

        [JsonProperty("ISO_18245")]
        public ISO_18245 ISO_18245 { get; set; }
    }

    // ---- ISO 4217 ------ //
    public class ISO_4217
    {
        [JsonProperty("Pblshd")]
        public string Pblshd { get; set; }

        [JsonProperty("CcyTbl")]
        public CurrencyTable CcyTbl { get; set; }
    }

    public class CurrencyTable
    {
        [JsonProperty("CcyNtry")]
        public ICollection<Currency> CcyNtry { get; set; }
    }

    // ------ ISO 18245 -------- //
    public class ISO_18245
    {
        [JsonProperty("Pblshd")]
        public string Pblshd { get; set; }

        [JsonProperty("MccTbl")]
        public MccTable MccTbl { get; set; }
    }

    public class MccTable
    {
        [JsonProperty("MccNtry")]
        public ICollection<MerchantCategory> MccNtry { get; set; }
    }
}
