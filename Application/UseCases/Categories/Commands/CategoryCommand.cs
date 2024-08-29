using Domain.Entities;
using MediatR;

namespace Application.UseCases.Categories.Commands
{
    public abstract class CategoryCommand : IRequest<Category>
    {
        public string? Name { get; set; }
    }
}
