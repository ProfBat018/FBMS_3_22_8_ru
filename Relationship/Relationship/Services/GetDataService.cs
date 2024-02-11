using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Relationship.Services;

public class GetDataService
{
    private readonly AcademyContext _context;

    public GetDataService(AcademyContext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAllData<T>(Expression<Func<T, bool>>? expression=null, string? relatives = null)
        where T : class, IEntity
    {
        IQueryable<T> query = _context.Set<T>().AsQueryable();

        if (relatives == null)
            return query.AsEnumerable();

        var tablesToInclude = relatives.Split(',', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var item in tablesToInclude)
        {
            query = query.Include(item);
        }

        if(expression != null)
            query = query.Where(expression);
        
        return query.AsEnumerable();
    }
    
 
    
}
    
