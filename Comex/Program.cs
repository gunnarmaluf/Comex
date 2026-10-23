using Comex.Menu;
using Comex.Modelo;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

Dictionary<string, Cliente> clientes = new Dictionary<string, Cliente>();
Dictionary<string, Produto> produtos = new Dictionary<string,Produto>();
Dictionary<int, MenuPrincipal> menu = new Dictionary<int, MenuPrincipal>();

menu.Add(1, new MenuCadastrarCliente());
menu.Add(2, new MenuListarCliente());
menu.Add(3, new MenuCadastrarProduto());
menu.Add(4, new MenuListarProduto());
menu.Add(5, new MenuListarProdutoOrdenadoPorNome());
menu.Add(6, new MenuOrdenarProdutosPeloPreco());
menu.Add(7, new MenuAjustarPreco());
menu.Add(8, new MenuAdicionarProdutoAoCarinho());
menu.Add(9, new MenuFecharCompra());
menu.Add(-1, new MenuSair());

CadastrarProdutos();
CadastrarClientes();

void CadastrarProdutos() //dados para preenchimento e teste
{

    Eletronico p1 = new Eletronico("Geladeira");
    p1.Potencia = 1500;
    p1.Descricao = "Geladeira Samasung";
    p1.Preco = 4999.99;
    p1.Voltagem = 110.00;
    produtos[p1.Nome] = p1;

    Eletronico p2 = new Eletronico("TV");
    p2.Potencia = 600;
    p2.Descricao = "TV Samasung";
    p2.Preco = 7699.99;
    p2.Voltagem = 110.00;
    produtos[p2.Nome] = p2;

    Produto p3 = new Produto("Caixa de Som");
    p3.Descricao = "Caixa de Som JBL";
    p3.Preco = 330.15;
    produtos[p3.Nome] = p3;

    Produto p4 = new Produto("Mouse");
    p4.Descricao = "Mouse Logitech";
    p4.Preco = 199.75;
    produtos[p4.Nome] = p4;

    Livro l1 = new Livro("O Navegante");
    l1.Preco = 120.15;
    l1.TotalPaginas = 1500;
    l1.Isbn = "1323298";
    produtos[l1.Nome] = l1;

    Livro l2 = new Livro("Senhor dos Anéis");
    l2.Preco = 180.55;
    l2.TotalPaginas = 2500;
    l2.Isbn = "13232999";
    produtos[l2.Nome] = l2;
}

void CadastrarClientes() //dados para preenchimento e teste
{
    Cliente c1 = new Cliente();
    c1.Nome = "Gunnar";
    c1.Profissao = "Auditor";
    c1.EMAIL = "gunnar@fazenda.sp.gov.br";
    c1.CPF = "123.123.123-01";
    c1.Endereco.Rua = "Rua Correia Dias" ;
    c1.Endereco.Numero = 441;
    c1.Endereco.Complemento = "1202";
    c1.Endereco.Bairro = "Paraíso";
    c1.Endereco.Cidade = "São Paulo";
    c1.Endereco.Estado = "SP";
    clientes[c1.Nome] = c1;

    Cliente c2 = new Cliente();
    c2.Nome = "Joao";
    c2.Profissao = "RH";
    c2.EMAIL = "joao@rh.com.br";
    c2.CPF = "123.123.123-02";
    c2.Endereco.Rua = "Avenida Rangel Pestana";
    c2.Endereco.Numero = 300;
    c2.Endereco.Complemento = "4 andar";
    c2.Endereco.Bairro = "Centro";
    c2.Endereco.Cidade = "São Paulo";
    c2.Endereco.Estado = "SP";
    clientes[c2.Nome] = c2;

    Cliente c3 = new Cliente();
    c3.Nome = "Jose";
    c3.Profissao = "Programador";
    c3.EMAIL = "jose@programar.com.br";
    c3.CPF = "123.123.123-03";
    c3.Endereco.Rua = "Rua Cubatão";
    c3.Endereco.Numero = 95;
    c3.Endereco.Complemento = "404";
    c3.Endereco.Bairro = "Paraíso";
    c3.Endereco.Cidade = "São Paulo";
    c3.Endereco.Estado = "SP";
    clientes[c3.Nome] = c3;


}

bool ExibirMenuDeOpcoes()
{
    Console.WriteLine("Menu de Opções:");
    Console.WriteLine("1. Cadastrar Cliente");
    Console.WriteLine("2. Listar Clientes");
    Console.WriteLine("3. Cadastrar Produto");
    Console.WriteLine("4. Listar Produtos");
    Console.WriteLine("5. Listar Produtos Ordenados Pelo Nome");
    Console.WriteLine("6. Listar Produtos Ordenados Pelo Preco");
    Console.WriteLine("7. Ajustar Preço de Produto");
    Console.WriteLine("8. Adicionar Produto ao Carrinho");
    Console.WriteLine("9. Fechar Compra");
    Console.WriteLine("-1. Sair");
    Console.Write("Digite o número da opção desejada:");

    int opcao = int.Parse(Console.ReadLine()!);
    Console.WriteLine("\nOpção selecionada: " + opcao);
    
    menu[opcao].Executar(clientes, produtos);
    if (opcao == -1) return false;
   
    return true;
}


while (ExibirMenuDeOpcoes()) { }



