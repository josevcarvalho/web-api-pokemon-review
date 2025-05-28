namespace PokemonReview.Domain.Infrastructure;

public interface IUnitOfWork
{
    Task BeginTransaction(CancellationToken cancellationToken = default);
    Task EndTransaction(bool success, CancellationToken cancellationToken = default);
}
