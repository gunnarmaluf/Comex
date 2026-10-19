using Comex.Modelo;

Dictionary<string, string> clientes = new Dictionary<string, string>();
Dictionary<string, Produto> produtos = new Dictionary<string,Produto>();
Dictionary<string, List<Produto>> carrinhoDeCompras = new Dictionary<string, List<Produto>>();
void ExibirMenuDeOpcoes()
{
    Console.WriteLine("Menu de Opções:");
    Console.WriteLine("1. Cadastrar Cliente");
    Console.WriteLine("2. Listar Clientes");
    Console.WriteLine("3. Cadastrar Produto");
    Console.WriteLine("4. Listar Produtos");
    Console.WriteLine("5. Ajustar Preço de Produto");
    Console.WriteLine("6. Adicionar Produto ao Carrinho");
    Console.WriteLine("7. Fechar Compra");
    Console.WriteLine("-1. Sair");
    Console.Write("Digite o número da opção desejada:");

    int opcao = int.Parse(Console.ReadLine()!);
    Console.WriteLine("\nOpção selecionada: " + opcao);

    switch (opcao)
    {

        case 1:
            cadastrarCliente(clientes);
            break;

        case 2:
            listarClientes(clientes);
            break;

        case 3:
            cadastrarProduto(produtos);
            break;

        case 4:
            listarProdutos(produtos);
            break;

        case 5:
            ajustarPrecoProduto(produtos);
            break;

        case 6:
            adicionarProdutoAoCarrinho(carrinhoDeCompras, produtos, clientes);
            break;

        case 7:
            fecharCompra(clientes, carrinhoDeCompras);
            break;

        case -1:
            Console.WriteLine("COMEX FINALIZADO");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

}

void fecharCompra(Dictionary<string, string> clientes, Dictionary<string, List<Produto>> carrinhoDeCompras)
{
    Console.WriteLine("**********Fechar Compra**********");
    Console.Write("Digite o nome do cliente:");
    string nomeCliente = Console.ReadLine()!;

    try
    {
        if (clientes.ContainsKey(nomeCliente))
        {
            if (carrinhoDeCompras.ContainsKey(nomeCliente))
            {
                Console.WriteLine($"O cliente {nomeCliente} possui os seguintes produtos em seu carrinho de compras:");
                double soma = 0;
                foreach (Produto produto in carrinhoDeCompras[nomeCliente])
                {
                    Console.Write($"\nProduto:{produto.Nome} \t\t Valor:{produto.Preco}");
                    soma = soma + produto.Preco;
                }

                Console.WriteLine($"\nTotal:{soma}");

                Console.Write("\nDigite o número do cartão de crédito:");
                string cartao = Console.ReadLine()!;
                Console.WriteLine($"\nRealizando o pagamento de R${soma} no cartão {cartao}");
                Thread.Sleep(3000);
                ExibirMenuDeOpcoes();
            }
            else
            {
                Console.WriteLine($"O cliente {nomeCliente} não possui carrinho");
                limpaTela();
                ExibirMenuDeOpcoes();
            }


        }
        else
        {
            Console.WriteLine($"O cliente {nomeCliente} não está cadastrado");
            limpaTela();
            ExibirMenuDeOpcoes();
        }
    }
    catch (Exception)
    {

        Console.WriteLine("Algo inesperado aconteceu.");
    }

    limpaTela();
    ExibirMenuDeOpcoes();

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
    ExibirMenuDeOpcoes();
}

void listarClientes(Dictionary<string, string> clientes)
{
    try
    {
        foreach (KeyValuePair<string, string> cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Key}, CPF: {cliente.Value}");
        }
    }
    catch (Exception)
    {

        Console.WriteLine("Algo inesperado aconteceu.");
    }

    Thread.Sleep(3000);
    limpaTela();
}

void cadastrarCliente(Dictionary<string, string> clientes)
{
    Console.Clear();
    Console.WriteLine("**********Registro de Cliente**********");
    Console.WriteLine("Digite o nome do cliente:");
    try
    {
        string nome = Console.ReadLine()!;
        Console.WriteLine("Digite o cpf do cliente:");
        string cpf = Console.ReadLine()!;

        clientes[nome] = cpf;
        carrinhoDeCompras[nome] = new List<Produto>();

        Console.WriteLine($"Usuário {nome} ({cpf}) cadastrado com sucesso!");
    }
    catch (Exception)
    {
        Console.WriteLine("Algo inesperado aconteceu.");
    }
    limpaTela();
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
        /*Console.WriteLine("Digite a quantidade do produto em estoque:");
        int quantidade = int.Parse(Console.ReadLine()!);*/

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

void adicionarProdutoAoCarrinho(Dictionary<string, List<Produto>> carrinhoDeCompras, Dictionary<string, Produto> produtos, Dictionary<string, string> clientes)
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
            /*Console.WriteLine($"Qual o preço do {nomeProduto}?");
            double preco = double.Parse(Console.ReadLine()!);*/
            Console.WriteLine($"Quantos {nomeProduto} deseja adicionar ao carrinho?");
            int quantidade = int.Parse(Console.ReadLine()!);
            if (produtos.ContainsKey(nomeProduto) && quantidade > 0)
            {
                Produto produto = produtos[nomeProduto];

                if (carrinhoDeCompras[nomeCliente] != null) //verificar se o cliente possui carrinho
                {

                    //se possuir carrinho, adiciona.
                    carrinhoDeCompras[nomeCliente].Add(produto);
                }
                Console.WriteLine($"Produto {nomeProduto} adicionado ao carrinho do cliente {nomeCliente}!");
                limpaTela();
            }
            else
            {
                Console.WriteLine("Produto não cadastrado!");
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

void limpaTela()
{
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void listarProdutos(Dictionary<string, Produto> produtos) {

    Console.Clear();
    Console.WriteLine("**********Lista de Produtos Cadastrados**********");
    
    try
    {

        foreach (Produto produto in produtos.Values) 
        {
            Console.WriteLine($"Produto: {produto.Nome}\t\t Preço: {produto.Preco} \t\t Quantidade: {produto.Quantidade}");
        
        }
        
    }
    catch (Exception)
    {
        Console.WriteLine("Algo inesperado aconteceu.");
    }
    limpaTela();
}

ExibirMenuDeOpcoes();



