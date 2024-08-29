using Domain.Entities;
using MediatR;

namespace Application.UseCases.Categories.Commands
{
    public class CategoryDeleteCommand : IRequest<Category>
    {
        public int Id { get; set; }

        public CategoryDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
