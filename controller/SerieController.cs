public class SerieController : IRepository<Serie>
{
    List<Serie> listSeries = new List<Serie>();

    public void Delete(int id)
    {
        listSeries[id].Excluded = true;
    }

    public Serie Get(int id)
    {
        return listSeries[id];
    }

    public List<Serie> GetAll()
    {
        return listSeries;
    }

    public void Post(Serie serie)
    {
        listSeries.Add(serie);
    }

    public void Update(int id, Serie serie)
    {
        listSeries[id] = serie;
    }
}