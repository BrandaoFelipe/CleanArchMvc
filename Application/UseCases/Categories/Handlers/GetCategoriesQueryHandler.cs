using Application.UseCases.Categories.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Categories.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoriesQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
