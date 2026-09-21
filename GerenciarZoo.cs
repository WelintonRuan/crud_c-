
using MySql.Data.MySqlClient;

public class GerenciadorZoo
{
    private string connectionString;

    public GerenciadorZoo(string connStr)
    {
        connectionString = connStr;
    }

    public void CadastrarZoo()
    {
        Console.Clear();
        Console.WriteLine("--- CADASTRAR ---");
        
        string? nome = LerTexto("Nome: ");
        
        string? especie = LerTexto("Especie: ");
        
        int idade = LerInteiro("Idade: ");
    
        string? habitat = LerTexto("Habitat: ");

        Zoo novoZoo = new Zoo(nome, especie, idade, habitat);

        using MySqlConnection conexao = new MySqlConnection(connectionString);
        try
        {
            conexao.Open();
            string sql = "INSERT INTO animais (nome, especie, idade, habitat) VALUES (@nome, @especie, @idade, @habitat);";
            using MySqlCommand cmd = new MySqlCommand(sql, conexao);
            
            cmd.Parameters.AddWithValue("@nome", novoZoo.Nome);
            cmd.Parameters.AddWithValue("@especie", novoZoo.Especie);
            cmd.Parameters.AddWithValue("@idade", novoZoo.Idade);
            cmd.Parameters.AddWithValue("@habitat", novoZoo.Habitat);
            
            cmd.ExecuteNonQuery();
            Console.WriteLine("\nZoo cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        Console.ReadLine();
    }

    public void ListarAnimais()
    {
        Console.Clear();
        Console.WriteLine("--- LISTA DE ANIMAIS ---");

        using MySqlConnection conexao = new MySqlConnection(connectionString);
        try
        {
            conexao.Open();
            string sql = "SELECT id, nome, especie, idade, habitat FROM animais;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexao);
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Zoo a = new Zoo();
                a.Id = reader.GetInt32("id");
                a.Nome = reader.GetString("nome");
                a.Especie = reader.GetString("especie");
                a.Idade = reader.GetInt32("idade");
                a.Habitat = reader.GetString("habitat");

                Console.WriteLine(a.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        Console.ReadLine();
    }

    public void BuscarZoo()
    {
        Console.Clear();
        Console.WriteLine("--- BUSCAR Zoo ---");
        int idBusca = LerInteiro("Digite o ID do Zoo: ");

        using MySqlConnection conexao = new MySqlConnection(connectionString);
        try
        {
            conexao.Open();
            string sql = "SELECT id, nome, especie, idade, habitat FROM animais WHERE id = @id;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", idBusca);
            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Zoo a = new Zoo();
                a.Id = reader.GetInt32("id");
                a.Nome = reader.GetString("nome");
                a.Especie = reader.GetString("especie");
                a.Idade = reader.GetInt32("idade");
                a.Habitat = reader.GetString("habitat");

                Console.WriteLine("\nRegistro encontrado:");
                Console.WriteLine(a.ToString());
            }
            else
            {
                Console.WriteLine("\nZoo não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        Console.ReadLine();
    }

    public void AtualizarZoo()
    {
        Console.Clear();
        Console.WriteLine("--- ATUALIZAR ---");
        int id = LerInteiro("ID do Zoo a ser atualizado: ");
        
        string nome = LerTexto("Novo nome: ");
        
        string especie = LerTexto("Nova Espécie: ");
       
        int idade = LerInteiro("Nova Idade: ");
       
        string habitat = LerTexto("Novo Habitat: ");

        using MySqlConnection conexao = new MySqlConnection(connectionString);
        try
        {
            conexao.Open();
            string sql = "UPDATE animais SET nome = @nome, especie = @especie, idade = @idade, habitat = @habitat WHERE id = @id;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@especie", especie);
            cmd.Parameters.AddWithValue("@idade", idade);
            cmd.Parameters.AddWithValue("@habitat", habitat);

            int linhas = cmd.ExecuteNonQuery();
            if (linhas > 0) Console.WriteLine("\nAtualizado com sucesso!");
            else Console.WriteLine("\nID não encontrado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        Console.ReadLine();
    }

    public void ExcluirZoo()
    {
        Console.Clear();
        Console.WriteLine("--- EXCLUIR ---");
        int id = LerInteiro("ID do Zoo a ser excluído: ");

        using MySqlConnection conexao = new MySqlConnection(connectionString);
        try
        {
            conexao.Open();
            string sql = "DELETE FROM animais WHERE id = @id;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);

            int linhas = cmd.ExecuteNonQuery();
            if (linhas > 0) Console.WriteLine("\nExcluído com sucesso!");
            else Console.WriteLine("\nID não encontrado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        Console.ReadLine();
    }



private string LerTexto(string mensagem)
{
    string? entrada;
    do
    {
        Console.Write(mensagem);
        entrada = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("Erro: Este campo não pode ficar vazio!");
        }
        else if (verif => char.isLetter(verif) || verif == ' ');
            {
                Console.WriteLine("Utilize apenas letras ou espaçamento quando necessário. ");
            }
    } while (string.IsNullOrWhiteSpace(entrada));

    return entrada; 
}


private int LerInteiro(string mensagem)
{
    int numero;
    Console.Write(mensagem);

    while (!int.TryParse(Console.ReadLine(), out numero) || numero < 0)
    {
        if (numero < 0)
            {
                Console.WriteLine("O número não pode ser negativo. ");
            }
            else
            {
                Console.WriteLine("Erro: Digite um número inteiro válido!");  
            }
        Console.Write(mensagem);
    }

    return numero;
}
}