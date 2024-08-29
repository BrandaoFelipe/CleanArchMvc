using Application.UseCases.Categories.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Categories.Handlers
{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryCreateCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
            if(category == null)
            {
                throw new ApplicationException($"Category cannot be null");
            }
            else
            {
                return await _repository.CreateAsync(category);
                
            }

            
        }
    }
}
