using Domain.Entities;
using MediatR;

namespace Application.UseCases.Products.Commands
{
    public class ProductDeleteComand : IRequest<Product>
    {
        public int Id { get; set; }

        public ProductDeleteComand(int id)
        {
            Id = id;
        }
    }
}
