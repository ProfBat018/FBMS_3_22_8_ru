using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;


namespace ProductRepository.Classes;

public class Repository<T> : IRepository<T> where T: class
{
    private readonly ProductContext _context;
    private readonly DbSet<T> contextSet;

    public Repository(ProductContext context)
    {
        _context = context;
        this.contextSet = _context.Set<T>(); // берет нужный DbSet
    }


    public async Task AddAsync(T entity)
    {
        await contextSet.AddAsync(entity);
    }

    // GetAllAsync(x => x.Color == "red", "Orders, Warehouse");
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = contextSet; 
        
        if (filter != null)
        {
            query = query.Where(filter);
        }
     
        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                         StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        return await query.ToListAsync();
    }
    
    // repo.GetAll(x => x.Color == black, "Category, Attribute")
    public async Task<PaginatedList<T>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? filter = null,
        string? includeProperties = null)
    {
        IQueryable<T> query = contextSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                         StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        // select COUNT(*) ....
        var count = await query.CountAsync(); // 75
            
        var items = await query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null,
        bool tracked = true)
    {
        if (tracked)
        {
            IQueryable<T> query = contextSet!;

            query = query.Where(filter!);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                             StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
        else
        {
            IQueryable<T> query = contextSet.AsNoTracking();

            query = query.Where(filter!);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                             StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
    }

    public void Remove(T entity)
    {
        contextSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        contextSet.RemoveRange(entity!);
    }
}