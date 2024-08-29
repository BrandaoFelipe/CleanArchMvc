using Domain.Entities;
using MediatR;

namespace Application.UseCases.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
