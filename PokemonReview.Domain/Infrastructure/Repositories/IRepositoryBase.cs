using PokemonReview.Domain.Entities;

namespace PokemonReview.Domain.Infrastructure.Repositories;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<T> GetById(int id, CancellationToken cancellationToken = default);
    Task<ICollection<T>> GetAll(CancellationToken cancellationToken = default);

    Task<bool> Exists(int id, CancellationToken cancellationToken = default);

    Task Create(T entity, CancellationToken cancellationToken = default);
    Task Delete(int id, CancellationToken cancellationToken = default);
    Task Update(T entity, CancellationToken cancellationToken = default);
}