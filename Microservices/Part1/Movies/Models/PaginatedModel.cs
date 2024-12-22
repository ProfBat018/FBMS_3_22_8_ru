namespace Movies.Models;

public class PaginatedModel<T> where T : IMovieEntity
{
    public uint Page { get; set; }
    public uint TotalPages { get; set; }

    public uint TotalResults { get; set; }
    
    public List<T> Results { get; set; }

    public PaginatedModel(IEnumerable<T> items, int page=1)
    {
        Page = (uint)page;
        Results = new List<T>(items);
        
        TotalResults = (uint)items.Count();

        TotalPages = TotalResults / 15;
    }
    
}