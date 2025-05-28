using PokemonReview.Domain.Entities;

namespace PokemonReview.Domain.Infrastructure.Repositories;

public interface ICountryRepository : IRepositoryBase<Country>
{
    Task<Country> GetCountryByOwner(int ownerId, CancellationToken cancellationToken = default);
    Task<ICollection<Owner>> GetOwnersFromACountry(int countryId, CancellationToken cancellationToken = default);
}
