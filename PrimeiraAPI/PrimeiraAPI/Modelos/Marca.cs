using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrimeiraAPI.Modelos
{
    public class Marca
    {
        [JsonPropertyName("Nome")]
        public String Nome { get; set; }

        //Adicionar as outras propriedades, conforme JSON de retorno
    }
}
