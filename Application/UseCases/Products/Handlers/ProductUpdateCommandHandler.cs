using Application.UseCases.Products.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Id could not be found");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _repository.UpdateAsync(product);
            }
            
        }
    }
}
