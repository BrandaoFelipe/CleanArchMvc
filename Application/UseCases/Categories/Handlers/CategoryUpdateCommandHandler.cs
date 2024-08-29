using Application.UseCases.Categories.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Categories.Handlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryUpdateCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAsync(request.Id);
            if(result == null)
            {
                throw new ApplicationException($"Could not found the Id ");
            }
            else
            {
                result.Update(request.Name);
                return await _repository.UpdateAsync(result);
            }
            
        }
    }
}
