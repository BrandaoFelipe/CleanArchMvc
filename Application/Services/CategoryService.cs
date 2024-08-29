using Application.DTOs;
using Application.Interfaces;
using Application.UseCases.Categories.Commands;
using Application.UseCases.Categories.Queries;
using AutoMapper;
using MediatR;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categoriesQuery = new GetCategoriesQuery();

            if (categoriesQuery == null)
                throw new ApplicationException($"Entity could not be loaded!");

            var result = await _mediator.Send(categoriesQuery);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task<CategoryDTO> GetCategoryById(int? id)
        {
            var categoriesByIdQuery = new GetCategoryByIdQuery(id.Value);

            if (categoriesByIdQuery == null)
                throw new ApplicationException($"Entity could not be loaded!");

            var result = await _mediator.Send(categoriesByIdQuery);

            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task Add(CategoryDTO catDTO)
        {
            var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(catDTO);
            await _mediator.Send(categoryCreateCommand);
        }

        public async Task Update(CategoryDTO catDTO)
        {
            var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(catDTO);
            await _mediator.Send(categoryUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            var categoryDeleteCommand = new CategoryDeleteCommand(id.Value);

            if (categoryDeleteCommand == null)
                throw new ApplicationException($"Entity could not be loaded!");

            var result = await _mediator.Send(categoryDeleteCommand);
        }
    }
}
