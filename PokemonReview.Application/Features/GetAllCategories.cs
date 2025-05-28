using AutoMapper;
using MediatR;
using PokemonReview.Application.Dtos;
using PokemonReview.Domain.Infrastructure.Repositories;

namespace PokemonReview.Application.Features;

public record GetAllCategoryQuery() : IRequest<ICollection<CategoryDto>>;

public class GetAllCategoriesHandler(IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoryQuery, ICollection<CategoryDto>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<ICollection<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAll(cancellationToken);
        return _mapper.Map<ICollection<CategoryDto>>(categories);
    }
}
