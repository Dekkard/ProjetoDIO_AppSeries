public class Serie : EBase
{
    private Genre _genre;
    private string _title;
    private string _description;
    private int _year;
    private bool _excluded;

    public Genre Genre { get => _genre; set => _genre = value; }
    public string Title { get => _title; set => _title = value; }
    public string Description { get => _description; set => _description = value; }
    public int Year { get => _year; set => _year = value; }
    public bool Excluded { get => _excluded; set => _excluded = value; }

    public Serie(int id, Genre genre, string title, string description, int year)
    {
        Id = id;
        _genre = genre;
        _title = title;
        _description = description;
        _year = year;
        _excluded = false;
    }
    public Serie()
    {
        Console.Write("Digite um título: ");
        _title = Console.ReadLine();

        Console.WriteLine("Lista de Gêneros: ");
        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine(i +": "+ Enum.GetName(typeof(Genre), i));
        }
        Console.Write("Escolha o Gênero: ");
        _genre = (Genre)Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite uma breve descrição: ");
        _title = Console.ReadLine();
        
        Console.Write("Digite o ano de lançamento: ");
        _year = Convert.ToInt32(Console.ReadLine());
    }
    public override string ToString()
    {
        return "ID: " + Id + "\n"
        + "\tTítulo: " + _title + "\n"
        + "\tGênero: " + _genre + "\n"
        + "\tDescrição: " + _description + "\n"
        + "\tAno: " + _year;
    }


}