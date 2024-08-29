using Application.UseCases.Categories.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);
        }
    }
}
