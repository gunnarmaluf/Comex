using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu;

internal class MenuCadastrarProduto: MenuPrincipal
{
    public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
    {
        cadastrarProduto(produtos);
    }

    void cadastrarProduto(Dictionary<string, Produto> produtos)
    {

        Console.Clear();
        Console.WriteLine("**********Registro de Produto**********");
        Console.WriteLine("Digite o nome do produto:");
        try
        {
            string nome = Console.ReadLine()!;
            Console.WriteLine("Digite o preço do produto (use vírgula ou ponto conforme cultura):");
            double preco = double.Parse(Console.ReadLine()!);

            Produto produto = new Produto(nome, preco);
            produto.Preco = preco;
            produtos[nome] = produto;

            Console.WriteLine($"Produto {nome} (R$ {preco}) cadastrado com sucesso!");
        }
        catch (Exception)
        {
            Console.WriteLine("Algo inesperado aconteceu.");
        }
        limpaTela();
    }

}
