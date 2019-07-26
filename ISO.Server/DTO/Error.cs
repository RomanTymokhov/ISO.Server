using Newtonsoft.Json;

namespace ISO.Server.DTO
{
    public class Error
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
