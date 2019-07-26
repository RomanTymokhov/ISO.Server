using Newtonsoft.Json;

namespace ISO.Server.DTO
{
    public class MerchantCategory
    {
        [JsonProperty("mcc")]
        public string Mcc { get; set; }

        [JsonProperty("edited_description")]
        public string Edited_description { get; set; }

        [JsonProperty("combined_description")]
        public string Combined_description { get; set; }

        [JsonProperty("usda_description")]
        public string Usda_description { get; set; }

        [JsonProperty("irs_description")]
        public string Irs_description { get; set; }

        [JsonProperty("irs_reportable")]
        public string Irs_reportable { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
