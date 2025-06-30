using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Intefaces
{
    public interface IBaseAppService<TDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task<TDto> CreateAsync(TCreateDto dto);
        Task<TDto> UpdateAsync(Guid id, TUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}