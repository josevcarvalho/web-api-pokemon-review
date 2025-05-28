using AutoMapper;
using MediatR;
using PokemonReview.Application.Dtos;
using PokemonReview.Domain.Infrastructure.Repositories;

namespace PokemonReview.Application.Features;

public record GetPokemonByCategoryQuery(int Id) : IRequest<ICollection<PokemonDto>>;

public class GetPokemonByCategoryHandler(IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<GetPokemonByCategoryQuery, ICollection<PokemonDto>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<ICollection<PokemonDto>> Handle(GetPokemonByCategoryQuery request, CancellationToken cancellationToken)
    {
        var pokemon = await _categoryRepository.GetPokemonByCategory(request.Id, cancellationToken);
        return _mapper.Map<ICollection<PokemonDto>>(pokemon);
    }
}
