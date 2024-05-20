using AGSRProject.Common.Models.Dto;
using AGSRProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.Common.Interfaces.Services
{
    public interface IService<T, P> where T : Entity where P : ModelDto
    {
        Task<P?> GetAsync(string id);
        Task<IEnumerable<P>> GetAllAsync();
        Task<string> AddAsync(P entity);
        Task<string> UpdateAsync(P entity);
        Task<string> DeleteAsync(string id);
    }
}
