using Application.UseCases.Products.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Products.Handlers
{
    public class GetProductByIdQueryhandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryhandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);

        }
    }
}
