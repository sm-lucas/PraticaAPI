using System;
using System.Net.Http;
using System.IO;
using System.ComponentModel;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Bibliography;

namespace PrimeiraAPI
{
    class Program
    {
        private static Marca marca;
        private static Modelo modelo;

        static void Main(string[] args)
        {
            // url das marcas dos veiculos 
            string urlMarca = "https://parallelum.com.br/fipe/api/v1/carros/marcas";

            //url dos modelos de veiculos 
            string urlModelo = "https://parallelum.com.br/fipe/api/v1/carros/marcas/59/modelos";

            //  Cliente http para chamar a API 
            HttpClient client = new HttpClient();

            // chama a API de marcas
            var responseMarcas = client.GetAsync("https://parallelum.com.br/fipe/api/v1/carros/marcas").Result;

            //obtém os dados da resposta COMO UMA STRING
            //E só obtem caso o retorno seja 200 (OK)
            string json = responseMarcas.Content.ReadAsStringAsync().Result;

            var marcas = JsonConvert.DeserializeObject<List<Marca>>(json); //Converte os dados para JSON em uma lista

            ///////////////////////////////////////////////////////////////////////////
            ///Converta o JSON em uma lista do objeto marca (mas crie todas as propriedades na marca primeiro. Deixei uma já criada
            ///Depois você itera, e trata o resultado
            ///O conteúdo de retorno de uma API geralmente é um JSON (string). E no código você converte para objetos antes de seguir com a lógica


            foreach (var marca in marcas)//Percorre as marcas. Fazendo a leitura
            {
                string nomeArquivo = marca.Nome.ToLower() + ".txt";// Cria o nome do arquivo
                StreamWriter writer = new StreamWriter(nomeArquivo);//Cria um arquivo
                var responseModelos = client.GetAsync("https://parallelum.com.br/fipe/api/v1/carros/marcas/59/modelos" + "?marca=" + marca.Codigo).Result; // Chama a API de modelos
                string modelosJson = responseModelos.Content.ReadAsStringAsync().Result; ; // Obtém os dados da resposta
                var modelos = JsonConvert.DeserializeObject<List<Modelo>>(modelosJson); // Converte os dados para JSON

                foreach (var modelo in modelos) //Percorre os modelos
                {
                    writer.WriteLine(modelo.Codigo + " --- " + modelo.Nome);// Escreve uma linha no arquivo
                }
                writer.Close();// Fecha o arquivo
                {
                    Console.WriteLine("Arquivos gerados com sucesso!");
                }
            }

        }
        class Marca
        {
            public string Nome { get; set; }
            public string Codigo { get; set; }
        }

        class Modelo
        {
            public string Nome { get; set; }
            public string Codigo { get; set; }
        }
    }
}
