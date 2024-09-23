using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProductData.Models;

namespace ProductRepo.Interfaces;

    public interface IRepository<T>
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = true);
      
        // GetAllSync(1, 12, x => x.color == "red")
        Task<PaginatedList<T>> GetAllPaginatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> filter = null, string includeProperties = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        Task AddAsync(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
