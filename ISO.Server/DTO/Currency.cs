using Newtonsoft.Json;

namespace ISO.Server.DTO
{
    public class Currency
    {
        [JsonProperty("CtryNm")]
        public string CtryNm { get; set; }

        [JsonProperty("CcyNm")]
        public string CcyNm { get; set; }

        [JsonProperty("Ccy")]
        public string Ccy { get; set; }

        [JsonProperty("CcyNbr")]
        public string CcyNbr { get; set; }

        [JsonProperty("CcyMnrUnts")]
        public string CcyMnrUnts { get; set; }
    }
}
