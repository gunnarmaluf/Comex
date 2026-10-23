using Comex.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu;

internal class MenuListarCliente: MenuPrincipal
{
    public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos)
    {
        listarClientes(clientes);
    }
    
    void listarClientes(Dictionary<string, Cliente> clientes)
    {
        try
        {
            foreach (Cliente cliente in clientes.Values)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"CPF: {cliente.CPF}");
                Console.WriteLine($"Email: {cliente.EMAIL}");
                Console.WriteLine($"Telefone: {cliente.Telefone}");
                Console.WriteLine($"Profissão: {cliente.Profissao}");
                Console.WriteLine($"Rua: {cliente.Endereco.Rua}");
                Console.WriteLine($"Numero: {cliente.Endereco.Numero}");
                Console.WriteLine($"Complemento: {cliente.Endereco.Complemento}");
                Console.WriteLine($"Bairro: {cliente.Endereco.Bairro}");
                Console.WriteLine($"Cidade: {cliente.Endereco.Cidade}");
                Console.WriteLine($"Estado: {cliente.Endereco.Estado}");
                Console.WriteLine("===================================================");
                Console.WriteLine();
            }
        }
        catch (Exception)
        {

            Console.WriteLine("Algo inesperado aconteceu.");
        }

        Thread.Sleep(3000);
        limpaTela();
    }

}
