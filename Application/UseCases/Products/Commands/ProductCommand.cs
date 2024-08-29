using Domain.Entities;
using MediatR;

namespace Application.UseCases.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product> //*
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        public int CategoryId { get; set; }
    }
}
//* abstract class that's going to be a base for the commands, thats why this is the abstract class, it cannot be instantiated