using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Comex.Menu
{
    internal class MenuConsultarProdutosApi :MenuPrincipal
    {
        public static HttpClient client = new HttpClient();

        public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
        {
            ConsultarProdutosApiAsync().GetAwaiter().GetResult() ;
        }

        public async Task ConsultarProdutosApiAsync() {

            try
            {
                var response = await client.GetStringAsync("https://fakestoreapi.com/products");
                List<Produto> produtos = JsonSerializer.Deserialize<List<Produto>>(response)!;

                foreach (Produto produto in produtos)
                {
                    Console.WriteLine("===================================================");
                    Console.WriteLine($"Produto: {produto.Nome}");
                    Console.WriteLine($"Preço: {produto.Preco}");
                    Console.WriteLine($"Quantidade: {produto.Quantidade}");
                    Console.WriteLine("===================================================");
                    Console.WriteLine();
                }
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Uma exceção ocorreu:" + ex.Message);
            }


            limpaTela();

        }

    }
}
