using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu;

internal class MenuFecharCompra : MenuPrincipal
{
    public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
    {
        fecharCompra(clientes);
    }

    void fecharCompra(Dictionary<string, Cliente> clientes)
    {
        Console.WriteLine("**********Fechar Compra**********");
        Console.Write("Digite o nome do cliente:");
        string nomeCliente = Console.ReadLine()!;

        try
        {
            if (clientes.ContainsKey(nomeCliente))
            {

               Console.WriteLine($"O cliente {nomeCliente} possui os seguintes produtos em seu carrinho de compras:");
               double soma = 0;
               foreach (Produto produto in clientes[nomeCliente].CarrinhoDeCompras)
               {
                  Console.WriteLine("===================================================");
                  Console.WriteLine($"Produto:{produto.Nome}");
                  Console.WriteLine($"Valor:{produto.Preco}");
                  Console.WriteLine($"Quantidade:{produto.Quantidade}");
                  Console.WriteLine("===================================================");

                    soma = soma + (produto.Preco * produto.Quantidade);
               }


               Console.WriteLine($"\nTotal:{soma}");
               Console.WriteLine("_____________________________________________________");

                Console.Write("\nDigite o número do cartão de crédito:");
               string cartao = Console.ReadLine()!;
               Console.WriteLine($"\nRealizando o pagamento de R${soma} no cartão {cartao}");
               Thread.Sleep(3000);

                //terminou a compra, limpa o carrinho
               clientes[nomeCliente].CarrinhoDeCompras.Clear();

            }
            else
            {
                Console.WriteLine($"O cliente {nomeCliente} não está cadastrado");
                limpaTela();

            }
        }
        catch (Exception)
        {

            Console.WriteLine("Algo inesperado aconteceu.");
        }

        limpaTela();        

    }


}
