using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
