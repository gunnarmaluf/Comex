using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu;

internal class MenuAjustarPreco: MenuPrincipal
{
    public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
    {
        ajustarPrecoProduto(produtos);
    }

    void ajustarPrecoProduto(Dictionary<string, Produto> produtos)
    {
        Console.Clear();
        Console.WriteLine("**********Alterar Preço de Produto**********");
        Console.WriteLine("Digite o nome do produto:");
        try
        {
            string nome = Console.ReadLine()!;
            if (produtos.ContainsKey(nome))
            {
                Console.WriteLine($"Preço atual do produto {nome}: R$ {produtos[nome].Preco}");
                Console.WriteLine("Digite o novo preço do produto (use vírgula ou ponto conforme cultura):");
                double novoPreco = double.Parse(Console.ReadLine()!);
                produtos[nome].Preco = novoPreco;
                Console.WriteLine($"Preço do produto {nome} atualizado para R$ {produtos[nome].Preco} com sucesso!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"Produto {nome} não cadastrado no sistema.");
                Thread.Sleep(1000);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Algo inesperado aconteceu.");
        }

        limpaTela();        
    }

}
