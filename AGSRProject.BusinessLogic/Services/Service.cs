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
    public class Service<T,P> : IService<T, P> where T : Entity where P : ModelDto
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;

        public Service(IRepository<T> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<string> AddAsync(P entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            return await _repository.AddAsync(_mapper.Map<T>(entity)).ContinueWith(r => r.Result);
        }

        public async Task<string> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id).ContinueWith(r => r.Result);
        }

        public async Task<IEnumerable<P>> GetAllAsync()
        {
            return await _repository.GetAllAsync().ContinueWith(r => _mapper.Map<IEnumerable<P>>(r.Result));
        }

        public async Task<P?> GetAsync(string id)
        {
            return await _repository.GetAsync(id).ContinueWith(r => _mapper.Map<P>(r.Result));
        }

        public async Task<string> UpdateAsync(P entity)
        {
            return await _repository.UpdateAsync(_mapper.Map<T>(entity)).ContinueWith(r => r.Result);
        }
    }
}
