using Application.UseCases.Categories.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Categories.Handlers
{
    public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryDeleteCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAsync(request.Id);
            if(result == null)
            {
                throw new ApplicationException($"Id could not be found");
            }
            else
            {
                return await _repository.DeleteAsync(result);
            }
            
        }
    }
}
