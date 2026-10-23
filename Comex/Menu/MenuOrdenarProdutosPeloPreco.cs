using Comex.Filtros;
using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu
{
    internal class MenuOrdenarProdutosPeloPreco:MenuPrincipal
    {
        public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
        {
            List<Produto> produtosOrdenados = Filtro.OrdenarProdutoPorPreco(produtos.Values.ToList());
            listarProdutos(produtosOrdenados);

        }

        void listarProdutos(List<Produto> produtos)
        {

            Console.Clear();
            Console.WriteLine("**********Lista de Produtos Ordenados Pelo Preco**********");

            try
            {

                foreach (Produto produto in produtos)
                {
                    Console.WriteLine("===================================================");
                    Console.WriteLine($"Produto: {produto.Nome}");
                    Console.WriteLine($"Preço: {produto.Preco}");
                    Console.WriteLine($"Quantidade: {produto.Quantidade}");
                    Console.WriteLine("===================================================");
                    Console.WriteLine();
                }
                Thread.Sleep(5000);
            }
            catch (Exception)
            {
                Console.WriteLine("Algo inesperado aconteceu.");
            }

            limpaTela();
        }
    }
}
