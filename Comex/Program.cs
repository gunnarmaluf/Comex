Dictionary<string, string> clientes = new Dictionary<string, string>();
Dictionary<string, float> produtos = new Dictionary<string, float>();
Dictionary<string, List<KeyValuePair<string, float>>> carrinhoDeCompras = new Dictionary<string, List<KeyValuePair<string, float>>>();
void ExibirMenuDeOpcoes()
{
    Console.WriteLine("Menu de Opções:");
    Console.WriteLine("1. Cadastrar Cliente");
    Console.WriteLine("2. Listar Clientes");
    Console.WriteLine("3. Cadastrar Produto");
    Console.WriteLine("4. Ajustar Preço de Produto");
    Console.WriteLine("5. Adicionar Produto ao Carrinho");
    Console.WriteLine("6. Fechar Compra");
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
        case -1:
            Console.WriteLine("COMEX FINALIZADO");
            return;

        case 3:
            cadastrarProduto(produtos);
            break;

        case 4:
            ajustarPrecoProduto(produtos);
            break;

        case 5:
            adicionarProdutoAoCarrinho(carrinhoDeCompras, produtos, clientes);
            break;

        case 6:
            fecharCompra(clientes, carrinhoDeCompras);
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

}

void fecharCompra(Dictionary<string, string> clientes, Dictionary<string, List<KeyValuePair<string, float>>> carrinhoDeCompras)
{
    Console.WriteLine("**********Fechar Compra**********");
    Console.Write("Digite o nome do cliente:");
    string nomeCliente = Console.ReadLine()!;

    if (clientes.ContainsKey(nomeCliente))
    {
        if (carrinhoDeCompras.ContainsKey(nomeCliente))
        {
            Console.WriteLine($"O cliente {nomeCliente} possui os seguintes produtos em seu carrinho de compras:");
            float soma = 0;
            foreach (KeyValuePair<string, float> produto in carrinhoDeCompras[nomeCliente])
            {
                Console.Write($"\nProduto:{produto.Key} \t\t Valor:{produto.Value}");
                soma = soma + produto.Value;
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

    limpaTela();
    ExibirMenuDeOpcoes();

}

void ajustarPrecoProduto(Dictionary<string, float> produtos)
{
    Console.Clear();
    Console.WriteLine("**********Alterar Preço de Produto**********");
    Console.WriteLine("Digite o nome do produto:");
    string nome = Console.ReadLine()!;
    if (produtos.ContainsKey(nome))
    {
        Console.WriteLine($"Preço atual do produto {nome}: R$ {produtos[nome]}");
        Console.WriteLine("Digite o novo preço do produto (use vírgula ou ponto conforme cultura):");
        float novoPreco = float.Parse(Console.ReadLine()!);
        produtos[nome] = novoPreco;
        Console.WriteLine($"Preço do produto {nome} atualizado para R$ {novoPreco} com sucesso!");
        Thread.Sleep(1000);
    }
    else
    {
        Console.WriteLine($"Produto {nome} não cadastrado no sistema.");
        Thread.Sleep(1000);
    }

    limpaTela();
    ExibirMenuDeOpcoes();
}

void listarClientes(Dictionary<string, string> clientes)
{
    foreach (KeyValuePair<string, string> cliente in clientes)
    {
        Console.WriteLine($"Nome: {cliente.Key}, CPF: {cliente.Value}");
    }

    Thread.Sleep(3000);
    limpaTela();
}

void cadastrarCliente(Dictionary<string, string> clientes)
{
    Console.Clear();
    Console.WriteLine("**********Registro de Cliente**********");
    Console.WriteLine("Digite o nome do cliente:");
    string nome = Console.ReadLine()!;
    Console.WriteLine("Digite o cpf do cliente:");
    string cpf = Console.ReadLine()!;

    clientes[nome] = cpf;
    carrinhoDeCompras[nome] = new List<KeyValuePair<string, float>>();

    Console.WriteLine($"Usuário {nome} ({cpf}) cadastrado com sucesso!");
    limpaTela();
}

void cadastrarProduto(Dictionary<string, float> produtos)
{
    Console.Clear();
    Console.WriteLine("**********Registro de Produto**********");
    Console.WriteLine("Digite o nome do produto:");
    string nome = Console.ReadLine()!;
    Console.WriteLine("Digite o preço do produto (use vírgula ou ponto conforme cultura):");
    float preco = float.Parse(Console.ReadLine()!);

    produtos[nome] = preco;

    Console.WriteLine($"Produto {nome} (R$ {preco}) cadastrado com sucesso!");
    limpaTela();
}

void adicionarProdutoAoCarrinho(Dictionary<string, List<KeyValuePair<string, float>>> carrinhoDeCompras, Dictionary<string, float> produtos, Dictionary<string, string> clientes)
{
    Console.Clear();
    Console.WriteLine("***** Adicionar Produto ao Carrinho *****");
    Console.WriteLine("Digite o nome do cliente:");
    string nomeCliente = Console.ReadLine()!;
    if (clientes.ContainsKey(nomeCliente))
    {
        Console.WriteLine("Qual produto deseja adicionar ao carrinho?");
        string nomeProduto = Console.ReadLine()!;
        if (produtos.ContainsKey(nomeProduto))
        {
            KeyValuePair<string, float> produto = new KeyValuePair<string, float>(nomeProduto, produtos[nomeProduto]);

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

void limpaTela()
{
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenuDeOpcoes();
}

ExibirMenuDeOpcoes();



