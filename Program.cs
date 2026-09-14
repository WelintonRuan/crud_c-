using MySql.Data.MySqlClient;

string connectionString = "Server=localhost;Database=zoo;Uid=root;Pwd=Senac2026;";

using var conexao = new MySqlConnection(connectionString);

try
{
    conexao.Open();
    Console.WriteLine("Conexão com o MySQL realizada com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao conectar: {ex.Message}");
}
