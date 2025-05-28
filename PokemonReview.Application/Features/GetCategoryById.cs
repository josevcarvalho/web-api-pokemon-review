using AutoMapper;
using MediatR;
using PokemonReview.Application.Dtos;
using PokemonReview.Domain.Infrastructure.Repositories;

namespace PokemonReview.Application.Features;

public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;

public class GetCategoryByIdHandler(IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(request.Id, cancellationToken);
        return _mapper.Map<CategoryDto>(category);
    }
}
