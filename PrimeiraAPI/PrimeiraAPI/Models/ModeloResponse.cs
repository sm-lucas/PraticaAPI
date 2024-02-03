using Newtonsoft.Json;

namespace PrimeiraAPI.Models
{
    public class ModeloResponse
    {
        [JsonProperty("modelos")]
        public List<Modelo> Modelos { get; set; }

        [JsonProperty("anos")]
        public List<Ano> Anos { get; set; }
    }
}
