public class Program
{
    public static void Main(string[] args)
    {
        SerieController sr = new SerieController();
        List<Serie> listSeries = sr.GetAll();
        Console.WriteLine("Bem-vindo ao gerenciador de séries.");
        while (true)
        {
            Console.WriteLine("Comandos:\n"
            + "\t 1: Listar séries:\n"
            + "\t 2: Inserir série:\n"
            + "\t 3: Alterar série:\n"
            + "\t 4: Deletar série:\n"
            + "\t S: Salvar lista de séries(breve): \n"
            + "\t C: Carregar lista de séries(breve): \n"
            + "\t X: fechar gerenciador:");
            Console.Write("Digite: ");
            string opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
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
                    break;
                case "C":
                case "c":
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