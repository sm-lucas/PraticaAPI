using System;
using System.Net.Http;
using System.IO;
using System.ComponentModel;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Bibliography;
using PrimeiraAPI.Models;

namespace PrimeiraAPI
{
    public class Program
    {
        private static readonly string URL_MARCA = "https://parallelum.com.br/fipe/api/v1/carros/marcas"; // url das marcas dos veiculos
        private static readonly string PATH_MODELOS = "/{marca_codigo}/modelos"; // caminho dos modelos por marca
        
        public static void Main(string[] args)
        {
            try
            {
                var jsonMarcas = ObterJsonDaAPI(URL_MARCA);
                var marcas = JsonConvert.DeserializeObject<List<Marca>>(jsonMarcas); //Converte os dados para JSON em uma lista

                ///////////////////////////////////////////////////////////////////////////
                ///Converta o JSON em uma lista do objeto marca (mas crie todas as propriedades na marca primeiro. Deixei uma já criada
                ///Depois você itera, e trata o resultado
                ///O conteúdo de retorno de uma API geralmente é um JSON (string). E no código você converte para objetos antes de seguir com a lógica
                foreach (var marca in marcas)//Percorre as marcas. Fazendo a leitura
                {
                    //Tratamento da API para recuperar modelos
                    var urlModelo = URL_MARCA + PATH_MODELOS.Replace("{marca_codigo}", marca.Codigo);
                    var modelosJson = ObterJsonDaAPI(urlModelo);
                    var modeloResponse = JsonConvert.DeserializeObject<ModeloResponse>(modelosJson); // Converte os dados para JSON

                    //Tratamento do arquivo
                    var nomeArquivo = "C:\\Users\\danil\\Desktop\\teste2024\\" + marca.Nome.ToLower().Replace("/", "_") + ".txt";// Cria o nome do arquivo

                    EscreveModelosNosArquivos(modeloResponse.Modelos, nomeArquivo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static void EscreveModelosNosArquivos(List<Modelo> modelos, string nomeArquivo)
        {
            using (var writer = new StreamWriter(nomeArquivo)) //Cria um streamWriter que escreve em arquivos
            {
                foreach (var modelo in modelos) //Percorre os modelos
                {
                    writer.WriteLine(modelo.Codigo + " --- " + modelo.Nome);// Escreve uma linha no arquivo
                }

                Console.WriteLine($"Arquivo {nomeArquivo} gerados com sucesso!");
            }
        }

        private static string ObterJsonDaAPI(string url)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Chamando a URL: " + url);
                var responseMarcas = client.GetAsync(url).Result;
                return responseMarcas.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
