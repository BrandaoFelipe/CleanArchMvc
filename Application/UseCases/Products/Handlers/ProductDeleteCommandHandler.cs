using Application.UseCases.Products.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Products.Handlers
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteComand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductDeleteCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductDeleteComand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAsync(request.Id);
            if (result == null)
            {
                throw new ApplicationException($"Id could not be found!");
            }
            else
            {
                return await _repository.DeleteAsync(result);
            }
            
        }
    }
}
