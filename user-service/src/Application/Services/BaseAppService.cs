using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Intefaces;
using Application.Intefaces.Common;
using AutoMapper;

namespace Application.Services
{
    public class BaseAppService<TEntity, TDto, TCreateDto, TUpdateDto> :
    IBaseAppService<TDto, TCreateDto, TUpdateDto> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        public BaseAppService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TDto> CreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> UpdateAsync(Guid id, TUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return default;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);

            return _mapper.Map<TDto>(entity);
        }
    }
}