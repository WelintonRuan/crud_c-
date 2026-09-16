public class Zoo
{

    private int id;
    private string? nome;
    private string? especie;
    private int idade;
    private string? habitat;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string? Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string? Especie
    {
        get { return especie; }
        set { especie = value; }
    }

    public int Idade
    {
        get { return idade; }
        set { idade = value; }
    }

    public string? Habitat
    {
        get { return habitat; }
        set { habitat = value; }
    }

 
    public Zoo() { }

    public Zoo(string nome, string especie, int idade, string habitat)
    {
        Nome = nome;
        Especie = especie;
        Idade = idade;
        Habitat = habitat;
    }


    public override string ToString()
    {
        return $"[{Id}] {Nome} | Espécie: {Especie} | Idade: {Idade} ano(s) | Habitat: {Habitat}";
    }
}