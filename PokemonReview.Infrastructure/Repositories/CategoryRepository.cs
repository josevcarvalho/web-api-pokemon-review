using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Infrastructure.Repositories;
using PokemonReview.Infrastructure.Data;

namespace PokemonReview.Infrastructure.Repositories;

public class CategoryRepository(DataContext context) : RepositoryBase<Category>(context), ICategoryRepository
{
    public async Task<ICollection<Pokemon>> GetPokemonByCategory(int categoryId, CancellationToken cancellationToken = default)
    {
        return await Context.Pokemon
            .Where(c => 
                c.PokemonCategories.Any(c => c.CategoryId == categoryId))
            .ToListAsync(cancellationToken);
    }
}
