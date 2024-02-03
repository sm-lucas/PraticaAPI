using Newtonsoft.Json;

namespace PrimeiraAPI.Models
{
    public class ResponseBase
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }
    }
}
