using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu
{
    internal class MenuListarProduto:MenuPrincipal
    {
        public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
        {
            listarProdutos(produtos);
        }

        void listarProdutos(Dictionary<string, Produto> produtos)
        {

            Console.Clear();
            Console.WriteLine("**********Lista de Produtos Cadastrados**********");

            try
            {

                foreach (Produto produto in produtos.Values)
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
