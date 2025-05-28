using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Infrastructure.Repositories;
using PokemonReview.Infrastructure.Data;

namespace PokemonReview.Infrastructure.Repositories;

public class CountryRepository(DataContext context) : RepositoryBase<Country>(context), ICountryRepository
{
    public Task<Country> GetCountryByOwner(int ownerId, CancellationToken cancellationToken = default)
    {
        return Context.Owners
            .Where(o => o.Id == ownerId)
            .Select(o => o.Country)
            .SingleAsync(cancellationToken);
    }

    public async Task<ICollection<Owner>> GetOwnersFromACountry(int countryId, CancellationToken cancellationToken = default)
    {
        return await Context.Countries
            .Where(c => c.Id == countryId)
            .SelectMany(c => c.Owners)
            .ToListAsync(cancellationToken);
    }
}
