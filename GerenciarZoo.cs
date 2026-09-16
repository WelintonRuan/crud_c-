using MySql.Data.MySqlClient;

public class GerenciadorZoo
{
    private string connectionString;

    // O construtor recebe a string de conexão quando a classe for instanciada
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
        int id = LerInteiro("ID do Zoo a ser atualizado:");
        
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


// Método para ler textos garantindo que não sejam nulos nem vazios
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
    } while (string.IsNullOrWhiteSpace(entrada));

    return entrada; // Retorna sempre uma string válida (não-nula)
}

// Método para ler números inteiros sem crashar se digitarem letras
private int LerInteiro(string mensagem)
{
    int numero;
    Console.Write(mensagem);

    while (!int.TryParse(Console.ReadLine(), out numero))
    {
        Console.WriteLine("Erro: Digite um número inteiro válido!");
        Console.Write(mensagem);
    }

    return numero;
}


public void BuscarZoo()
{
    Console.Clear();
    Console.WriteLine("--- BUSCAR ANIMAL POR ID ---");
    int idBusca = LerInteiro("Digite o ID do animal: ");

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
            Console.WriteLine("\nAnimal não encontrado.");
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine($"Erro de banco de dados: {ex.Message}");
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
    int id = LerInteiro("ID do animal a ser atualizado: ");

    string nome = LerTexto("Novo Nome: ");
    string especie = LerTexto("Nova Espécie: ");
    int idade = LerInteiro("Nova Idade: ", 0, 150);
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
    catch (MySqlException ex)
    {
        Console.WriteLine($"Erro de banco de dados: {ex.Message}");
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
    int id = LerInteiro("ID do animal a ser excluído: ");

    Console.Write($"Tem certeza que deseja excluir o ID {id}? (S/N): ");
    string? confirmacao = Console.ReadLine();
    if (confirmacao?.Trim().ToUpper() != "S")
    {
        Console.WriteLine("\nOperação cancelada.");
        Console.ReadLine();
        return;
    }

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
    catch (MySqlException ex)
    {
        Console.WriteLine($"Erro de banco de dados: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadLine();
}


public void BuscarPorNomeOuEspecie()
{
    Console.Clear();
    Console.WriteLine("--- BUSCAR POR NOME/ESPÉCIE ---");
    string termo = LerTexto("Digite o nome ou espécie (ou parte dele): ");

    using MySqlConnection conexao = new MySqlConnection(connectionString);
    try
    {
        conexao.Open();
        string sql = @"SELECT id, nome, especie, idade, habitat 
                        FROM animais 
                        WHERE nome LIKE @termo OR especie LIKE @termo;";
        using MySqlCommand cmd = new MySqlCommand(sql, conexao);
        cmd.Parameters.AddWithValue("@termo", $"%{termo}%");
        using MySqlDataReader reader = cmd.ExecuteReader();

        bool encontrou = false;
        while (reader.Read())
        {
            encontrou = true;
            Zoo a = new Zoo();
            a.Id = reader.GetInt32("id");
            a.Nome = reader.GetString("nome");
            a.Especie = reader.GetString("especie");
            a.Idade = reader.GetInt32("idade");
            a.Habitat = reader.GetString("habitat");
            Console.WriteLine(a.ToString());
        }

        if (!encontrou)
            Console.WriteLine("\nNenhum resultado encontrado.");
    }
    catch (MySqlException ex)
    {
        Console.WriteLine($"Erro de banco de dados: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadLine();
}


public void ExibirEstatisticas()
{
    Console.Clear();
    Console.WriteLine("--- ESTATÍSTICAS ---");

    using MySqlConnection conexao = new MySqlConnection(connectionString);
    try
    {
        conexao.Open();

        string sqlTotal = "SELECT COUNT(*) FROM animais;";
        using MySqlCommand cmdTotal = new MySqlCommand(sqlTotal, conexao);
        long total = (long)cmdTotal.ExecuteScalar();

        string sqlMedia = "SELECT AVG(idade) FROM animais;";
        using MySqlCommand cmdMedia = new MySqlCommand(sqlMedia, conexao);
        object mediaObj = cmdMedia.ExecuteScalar();
        double media = mediaObj != DBNull.Value ? Convert.ToDouble(mediaObj) : 0;

        Console.WriteLine($"Total de animais: {total}");
        Console.WriteLine($"Idade média: {media:F1} anos");

        Console.WriteLine("\nQuantidade por espécie:");
        string sqlPorEspecie = "SELECT especie, COUNT(*) as qtd FROM animais GROUP BY especie ORDER BY qtd DESC;";
        using MySqlCommand cmdEspecie = new MySqlCommand(sqlPorEspecie, conexao);
        using MySqlDataReader reader = cmdEspecie.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($" - {reader.GetString("especie")}: {reader.GetInt32("qtd")}");
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine($"Erro de banco de dados: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    Console.ReadLine();
}


private int LerInteiro(string mensagem, int min = int.MinValue, int max = int.MaxValue)
{
    int numero;
    bool valido;

    do
    {
        Console.Write(mensagem);
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Erro: Digite um número inteiro válido!");
            Console.Write(mensagem);
        }

        valido = numero >= min && numero <= max;
        if (!valido)
            Console.WriteLine($"Erro: o valor deve estar entre {min} e {max}.");

    } while (!valido);

    return numero;
}