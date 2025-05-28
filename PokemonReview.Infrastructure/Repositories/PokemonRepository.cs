using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Infrastructure.Repositories;
using PokemonReview.Infrastructure.Data;

namespace PokemonReview.Infrastructure.Repositories;

public class PokemonRepository(DataContext context) : RepositoryBase<Pokemon>(context), IPokemonRepository
{
    public async Task<decimal> GetPokemonRating(int id, CancellationToken cancellationToken = default)
    {
        var reviews = Context.Reviews.Where(p => p.Pokemon.Id == id);

        return await reviews.AnyAsync(cancellationToken) ? (reviews.Sum(r => r.Rating) / reviews.Count()) : decimal.Zero;
    }
}
