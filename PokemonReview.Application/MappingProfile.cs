using AutoMapper;
using PokemonReview.Application.Dtos;
using PokemonReview.Domain.Entities;

namespace PokemonReview.Application;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Pokemon, PokemonDto>();
    }
}
