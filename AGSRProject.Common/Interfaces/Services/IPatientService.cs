using AGSRProject.Common.Models.Dto;
using AGSRProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.Common.Interfaces.Services
{
    public interface IPatientService : IService<Patient, PatientDto>
    {
        Task<IEnumerable<PatientDto>> GetPatientsByBirthDayAsync(string birthDay);
    }
}
