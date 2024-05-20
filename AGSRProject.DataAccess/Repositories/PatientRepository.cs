using AGSRProject.Common.Interfaces.Repositories;
using AGSRProject.Common.Models.Entities;
using AGSRProject.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.DataAccess.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public virtual async Task<IEnumerable<Patient>> FindAsync(Expression<Func<Patient, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return await _dbSet.AsNoTracking().Where(filter).ToListAsync().ConfigureAwait(false);
        }
    }
}
