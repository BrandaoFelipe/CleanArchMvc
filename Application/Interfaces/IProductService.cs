using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int? id);        
        Task Add(ProductDTO prodDTO);
        Task Update(ProductDTO prodDTO);
        Task Delete(int? id);
    }
}
