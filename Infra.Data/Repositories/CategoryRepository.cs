using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}
