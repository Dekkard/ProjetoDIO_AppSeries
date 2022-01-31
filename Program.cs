public class Program
{
    public static void Main(string[] args)
    {
        SerieController sr = new SerieController();
        List<Serie> listSeries;
        string path = Path.Combine(Environment.CurrentDirectory + "\\Lista de Séries.txt");
        Console.WriteLine("Bem-vindo ao gerenciador de séries.");
        while (true)
        {
            Console.WriteLine("Comandos:\n"
            + "\t 1: Listar séries:\n"
            + "\t 2: Inserir série:\n"
            + "\t 3: Alterar série:\n"
            + "\t 4: Deletar série:\n"
            + "\t S: Salvar lista de séries: \n"
            + "\t C: Carregar lista de séries: \n"
            + "\t X: fechar gerenciador:");
            Console.Write("Digite: ");
            string opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
                    listSeries = sr.GetAll();
                    if (listSeries.Count() == 0)
                    {
                        Console.WriteLine("Nenhuma série registrada");
                    }
                    else
                    {
                        foreach (Serie s1 in listSeries)
                        {
                            Console.WriteLine(s1.ToString());
                        }
                    }
                    break;
                case "2":
                    Serie s2 = new Serie();
                    int newId;
                    while (true)
                    {
                        try
                        {
                            newId = new Random().Next(1, 5100);
                            s2.Id = newId;
                            Serie foundS = sr.Get(newId);
                            break;
                        }
                        catch (System.ArgumentOutOfRangeException e)
                        {
                            break;
                        }
                    }
                    // listSeries.Add(s2);
                    sr.Post(s2);
                    break;
                case "3":
                    listSeries = sr.GetAll();
                    if (listSeries.Count() == 0)
                    {
                        Console.WriteLine("Nenhuma série registrada");
                    }
                    else
                    {
                        Console.Write("Digite o Id da série: ");
                        int idUp = Convert.ToInt32(Console.ReadLine());
                        sr.Update(idUp, new Serie());
                    }
                    break;
                case "4":
                    listSeries = sr.GetAll();
                    if (listSeries.Count() == 0)
                    {
                        Console.WriteLine("Nenhuma série registrada");
                    }
                    else
                    {
                        Console.Write("Digite o Id da série: ");
                        int idDel = Convert.ToInt32(Console.ReadLine());
                        sr.Delete(idDel);
                    }
                    break;
                case "S":
                case "s":
                    var file1 = File.CreateText(path);
                    listSeries = sr.GetAll();
                    foreach (Serie ss in listSeries)
                    {
                        string pepareLine = ss.Id + ";" + ((int)ss.Genre) + ";" + ss.Title + ";" + ss.Description + ";" + ss.Year;
                        file1.WriteLine(pepareLine);
                    }
                    file1.Close();
                    break;
                case "C":
                case "c":
                    var file2 = File.OpenRead(path);
                    StreamReader streamReader = new StreamReader(file2);
                    while (!streamReader.EndOfStream)
                    {
                        string[] lineFields = streamReader.ReadLine().Split(";");
                        sr.Post(new Serie(Convert.ToInt32(lineFields[0]), (Genre)int.Parse(lineFields[1]) , lineFields[2], lineFields[3], Convert.ToInt32(lineFields[4])));
                    }
                    file2.Close();
                    break;
                case "X":
                case "x":
                    break;
                default:
                    Console.WriteLine("Comando não reconhecido");
                    continue;
            }
            if (opt.Equals("X") || opt.Equals("x")) break;
        }
    }
}