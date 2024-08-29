using Application.DTOs;
using Application.UseCases.Products.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            
        }
    }
}
