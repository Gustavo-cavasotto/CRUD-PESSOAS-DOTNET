using CRUD;

List<Pessoa> pessoas = new List<Pessoa>();

while (true)
{
    Console.WriteLine("Selecione uma opção: ");
    Console.WriteLine("1 - Inserir uma Pessoa: ");
    Console.WriteLine("2 - Exibir todas as Pessoas: ");
    Console.WriteLine("3 - Atualizar os dados de uma pessoa: ");
    Console.WriteLine("4 - Excluir uma Pessoa: ");
    Console.WriteLine("5 - Sair do programa");

    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            InserirPessoa(pessoas);
            break;
        case 2:
            ExibirPessoas(pessoas);
            break;
        case 3:
            AtualizarPessoa(pessoas);
            break;
        case 4:
            ExcluirPessoa(pessoas);
            break;
        case 5:
            // Encerra o programa
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opção Inválida");
            break;
    }

}

static void InserirPessoa(List<Pessoa> pessoas){
    Console.WriteLine("Digite o nome da Pessoa: ");
    string nome = Console.ReadLine();

    Console.WriteLine("Digite o telefone da Pessoa: ");
    string telefone = Console.ReadLine();

    Pessoa novaPessoa = new Pessoa{
        Id = Guid.NewGuid(),
        Nome = nome,
        Telefone = telefone,
    };
    // Criamos um novo objeto com uma variável novaPessoa com as variavéis "nome e telefone" e atribuimos elas aos atributos

    pessoas.Add(novaPessoa);
    // Após isso, adicionamos a novaPessoa a lista de pessoas
    Console.WriteLine("Pessoa Adicionada com Sucesso!");
}

static void ExibirPessoas(List<Pessoa> pessoas){
    Console.WriteLine("Exibindo todas as pessoas cadastradas no banco de dados");

    foreach (Pessoa pessoa in pessoas){
        Console.WriteLine($"ID: {pessoa.Id}, Nome: {pessoa.Nome}, Telefone: {pessoa.Telefone}");
    }
    // Para cada registro do tipo pessoa dentro da lista "pessoas" exibimos todos os dados, com foreach
}

static void AtualizarPessoa(List<Pessoa> pessoas){
    Console.WriteLine("Digite o ID da pessoa que deseja atualizar");
    Guid id = Guid.Parse(Console.ReadLine());
    // Passamos para Guid, para não dar erro na pesquisa
    Pessoa pessoa = pessoas.Find(p => p.Id == id);
    // Busca na lista de pessoas de acordo com o ID digitado

    if (pessoa != null){
        Console.WriteLine("Digite o novo nome da pessoa");
        string novoNome = Console.ReadLine();

        Console.WriteLine("Digite o novo telefone da pessoa");
        string novoTelefone = Console.ReadLine();

        // Atribui os novos dados do console a variável 'pessoa', que trouxe o registro certo de acordo com o id digitado na consulta
        pessoa.Nome = novoNome;
        pessoa.Telefone = novoTelefone;

        Console.WriteLine("Pessoa adicionada com sucesso!");
    }
    else{
        Console.WriteLine("Pessoa não encontrada!");
    }
}

static void ExcluirPessoa(List<Pessoa> pessoas)
{
    Console.WriteLine("Digite o ID da pessoa que deseja excluir:");
    Guid id = Guid.Parse(Console.ReadLine());

    // Procura a pessoa na lista pelo ID informado
    Pessoa pessoa = pessoas.FirstOrDefault(p => p.Id == id);
    // Busca a primeira pessoa da lista com o valor do id digitado, caso constrário cai no if.

    if (pessoa == null)
    {
        Console.WriteLine("Pessoa não encontrada na lista.");
    }
    else
    {
        pessoas.Remove(pessoa);
        Console.WriteLine("Pessoa removida com sucesso.");
    }
}