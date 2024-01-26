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

            //obtém os dados da resposta COMO UMA STRING
            //E só obtem caso o retorno seja 200 (OK)
            var json = responseMarcas.Content.ReadAsStringAsync().Result;

            ///////////////////////////////////////////////////////////////////////////
            ///Converta o JSON em uma lista do objeto marca (mas crie todas as propriedades na marca primeiro. Deixei uma já criada
            ///Depois você itera, e trata o resultado
            ///O conteúdo de retorno de uma API geralmente é um JSON (string). E no código você converte para objetos antes de seguir com a lógica

            //Percorre as marcas. Fazendo a leitura
            //foreach (var marca in marcas)
            //{
                // Cria o nome do arquivo
                //string nomeArquivo = marca.Nome.ToLower() + ".txt";

                //Cria um arquivo
                //StreamWriter writer = new StreamWriter(nomeArquivo);

                //obs:Continuar verificando erro em Nome na linha 31 

            //}
        }
    }
}