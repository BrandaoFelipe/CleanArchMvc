using Application.DTOs;
using Application.Interfaces;
using Application.UseCases.Products.Queries;
using Application.UseCases.Products.Commands;
using AutoMapper;
using MediatR;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new ApplicationException($"Entity could not be loaded!");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);

        }        

        public async Task<ProductDTO> GetProductById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new ApplicationException($"Id could not be found!");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Add(ProductDTO prodDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(prodDTO);
            await _mediator.Send(productCreateCommand);
        }
        public async Task Update(ProductDTO prodDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(prodDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            var productDeleteCommand = new ProductDeleteComand(id.Value);

            if (productDeleteCommand == null)
                throw new ApplicationException($"Id could not be found!");

            await _mediator.Send(productDeleteCommand);
        }

    }
}
