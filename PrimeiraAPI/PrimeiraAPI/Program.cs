using System;
using System.Net.Http;
using System.IO;


namespace PrimeiraAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            // url das marcas dos veiculos 
            string urlMarca = "https://parallelum.com.br/fipe/api/v1/carros/marcas";

            //url dos modelos de veiculos 
            string urlModelo = "https://parallelum.com.br/fipe/api/v1/carros/marcas/59/modelos";

            //  Cliente http para chamar a API 
            HttpClient client = new HttpClient();

            // chama a API marcas
            var responseMarcas = client.GetAsync("https://parallelum.com.br/fipe/api/v1/carros/marcas").Result;

            //obtém os dados da resposta
            var marcas = responseMarcas.Content.ReadAsStringAsync().Result;

            //Percorre as marcas. Fazendo a leitura
            foreach (var marca in marcas)
            {
                // Cria o nome do arquivo
                string nomeArquivo = marca.Nome.ToLower() + ".txt";

                //Cria um arquivo
                StreamWriter writer = new StreamWriter(nomeArquivo);

                //obs:Continuar verificando erro em Nome na linha 31 

            }
        }
    }
}