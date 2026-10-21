using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu;

internal class MenuAdicionarProdutoAoCarinho : MenuPrincipal
{
    public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
    {
        adicionarProdutoAoCarrinho(produtos,clientes);
    }

    void adicionarProdutoAoCarrinho(Dictionary<string, Produto> produtos, Dictionary<string, Cliente> clientes)
    {
        Console.Clear();
        Console.WriteLine("***** Adicionar Produto ao Carrinho *****");
        Console.WriteLine("Digite o nome do cliente:");
        try
        {
            string nomeCliente = Console.ReadLine()!;
            if (clientes.ContainsKey(nomeCliente))
            {
                Console.WriteLine("Qual produto deseja adicionar ao carrinho?");
                string nomeProduto = Console.ReadLine()!;
                Console.WriteLine($"Quantos {nomeProduto} deseja adicionar ao carrinho?");
                int quantidade = int.Parse(Console.ReadLine()!);
                if (produtos.ContainsKey(nomeProduto) && quantidade > 0)
                {
                    Produto produto = produtos[nomeProduto];
                    produto.Quantidade = quantidade;

                    if (clientes[nomeCliente].CarrinhoDeCompras != null) //verificar se o cliente possui carrinho
                    {

                        //se possuir carrinho, adiciona.
                        clientes[nomeCliente].CarrinhoDeCompras.Add(produto);
                    }
                    Console.WriteLine($"Produto {nomeProduto} adicionado ao carrinho do cliente {nomeCliente}!");
                    limpaTela();
                }
                else
                {
                    Console.WriteLine("Produto não cadastrado ou sem quantidade!");
                    limpaTela();
                }

            }
            else
            {
                Console.WriteLine("Cliente não cadastrado!");
                limpaTela();
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Algo inesperado aconteceu.");
        }

    }


}
