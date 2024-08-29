using Application.DTOs;
using Application.UseCases.Categories.Commands;
using Application.UseCases.Products.Commands;
using AutoMapper;

namespace Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductCreateCommand, ProductDTO>();
            CreateMap<ProductUpdateCommand, ProductDTO>();

            CreateMap<CategoryCreateCommand, CategoryDTO>().ReverseMap();
            CreateMap<CategoryUpdateCommand, CategoryDTO>().ReverseMap();
        }
    }
}
