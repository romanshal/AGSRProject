using AGSRProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.Common.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<T?> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<string> AddAsync(T entity);
        Task<string> UpdateAsync(T entity);
        Task<string> DeleteAsync(string id);
    }
}
