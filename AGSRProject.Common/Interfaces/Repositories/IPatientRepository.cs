using AGSRProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.Common.Interfaces.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> FindAsync(Expression<Func<Patient, bool>> filter);
    }
}
