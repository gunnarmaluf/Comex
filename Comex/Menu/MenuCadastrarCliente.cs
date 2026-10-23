using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu;

internal class MenuCadastrarCliente: MenuPrincipal
{
    public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
    {
        cadastrarCliente(clientes);
    }
    
    void cadastrarCliente(Dictionary<string, Cliente> clientes)
    {
        Console.Clear();
        Console.WriteLine("**********Registro de Cliente**********");
        Console.WriteLine("Digite o nome do cliente:");
        try
        {
            Cliente cliente = new Cliente();
            Endereco endereco = new Endereco();

            cliente.Nome = Console.ReadLine()!;
            Console.WriteLine("Digite o cpf do cliente:");
            cliente.CPF = Console.ReadLine()!;
            Console.WriteLine("Digite o email:");
            cliente.EMAIL = Console.ReadLine()!;
            Console.WriteLine("Digite a Profissão:");
            cliente.Profissao = Console.ReadLine()!;
            Console.WriteLine("Digite o telefone:");
            cliente.Telefone = Console.ReadLine()!;
            Console.WriteLine("Digite a rua:");
            endereco.Rua = Console.ReadLine()!;
            Console.WriteLine("Digite o numero:");
            endereco.Numero = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite o complemento:");
            endereco.Complemento = Console.ReadLine()!;
            Console.WriteLine("Digite o bairro:");
            endereco.Bairro = Console.ReadLine()!;
            Console.WriteLine("Digite a cidade:");
            endereco.Cidade = Console.ReadLine()!;
            Console.WriteLine("Digite o Estado:");
            endereco.Estado = Console.ReadLine()!;

            cliente.Endereco = endereco;

            clientes[cliente.Nome] = cliente;


            Console.WriteLine($"Usuário {cliente.Nome} ({cliente.CPF}) cadastrado com sucesso!");
        }
        catch (Exception)
        {
            Console.WriteLine("Algo inesperado aconteceu.");
        }
        limpaTela();
    }

    

}
