using MySql.Data.MySqlClient;

string connectionString = "Server=localhost;Database=zoo;Uid=root;Pwd=Senac2026;";

GerenciadorZoo banco = new GerenciadorZoo(connectionString);

bool  executando = true;

while(executando)
{
    Console.Clear();
    Console.WriteLine("SISTEMA DE ZOOLOGICO");
    Console.WriteLine("1- Cadastrar animal");
    Console.WriteLine("2- Listar animais");
    Console.WriteLine("3- Buscar animal");
    Console.WriteLine("4- Atualizar animal");
    Console.WriteLine("5- Excluir animal");
    Console.WriteLine("0- Sair");

    string? opcao = Console.ReadLine();

    if (opcao == "1")
    {
        banco.CadastrarZoo();
        continue;
    }
    else if (opcao == "2")
    {
        banco.ListarAnimais();
        continue;
    }
    else if (opcao == "3")
    {
        banco.BuscarZoo();
        continue;
    }
    else if (opcao == "4")
    {
        banco.AtualizarZoo();
        continue;
    }
    else if (opcao == "5")
    {
        banco.ExcluirZoo();
        continue;
    }
    else if (opcao == "0")
    {
        executando = false;
        break;
    }
    else
    {
        continue;
    }
}