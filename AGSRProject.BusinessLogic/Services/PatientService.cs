using AGSRProject.Common.Interfaces.Repositories;
using AGSRProject.Common.Interfaces.Services;
using AGSRProject.Common.Models.Dto;
using AGSRProject.Common.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.BusinessLogic.Services
{
    public class PatientService : Service<Patient, PatientDto>, IPatientService
    {
        new private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<PatientDto>> GetPatientsByBirthDayAsync(string birthDate)
        {
            DateTime date;
            string prefix = string.Empty;
            if (string.IsNullOrEmpty(birthDate))
            {
                return null;
            }

            if (char.IsLetter(birthDate[0]))
            {
                prefix = birthDate[..2];

                date = DateTime.Parse(birthDate[2..]);
            }
            else
            {
                date = DateTime.Parse(birthDate);
            }

            DateTime dateFrom;
            DateTime dateTo;

            switch (prefix)
            {
                case "eq":
                    dateFrom = date;
                    dateTo = date.AddDays(1).AddHours(0).AddMinutes(0).AddMilliseconds(0);

                    return await _repository.FindAsync(patient => patient.BirthDate >= dateFrom && patient.BirthDate < dateTo)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                case "ne":
                    dateFrom = date;
                    dateTo = date.AddDays(1).AddHours(0).AddMinutes(0).AddMilliseconds(0);

                    return await _repository.FindAsync(patient => patient.BirthDate < dateFrom && patient.BirthDate > dateTo)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                case "lt":
                    dateTo = date;

                    return await _repository.FindAsync(patient => patient.BirthDate < dateTo)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                case "gt":
                    dateFrom = date;

                    return await _repository.FindAsync(patient => patient.BirthDate > dateFrom)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                case "le":
                    dateTo = date;

                    return await _repository.FindAsync(patient => patient.BirthDate <= dateTo)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                case "ge":
                    dateFrom = date;

                    return await _repository.FindAsync(patient => patient.BirthDate >= dateFrom)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                case "sa":
                    dateFrom = date.AddDays(1);

                    return await _repository.FindAsync(patient => patient.BirthDate >= dateFrom)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                case "eb":
                    return await _repository.FindAsync(patient => patient.BirthDate < date)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                case "ap":
                    return await _repository.FindAsync(patient => patient.BirthDate == date)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));

                default:
                    return await _repository.FindAsync(patient => patient.BirthDate == date)
                        .ContinueWith(r => _mapper.Map<IEnumerable<PatientDto>>(r.Result));
            }
        }
    }
}
