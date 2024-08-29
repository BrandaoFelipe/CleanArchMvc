using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetCategoryById(int? id);
        Task Add(CategoryDTO catDTO);
        Task Update(CategoryDTO catDTO);
        Task Delete(int? id);
    }
}
