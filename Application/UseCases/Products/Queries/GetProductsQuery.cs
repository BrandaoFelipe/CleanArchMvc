using Domain.Entities;
using MediatR;

namespace Application.UseCases.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
