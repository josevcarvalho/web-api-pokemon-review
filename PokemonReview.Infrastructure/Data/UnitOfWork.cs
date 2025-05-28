namespace PokemonReview.Infrastructure.Data;

public class UnitOfWork(DataContext context)
{
    private readonly DataContext _context = context;

    public Task SaveChanges(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public Task BeginTransaction(CancellationToken cancellationToken = default)
    {
        return _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task EndTransaction(bool success, CancellationToken cancellationToken = default)
    {
        var @task = success 
            ? _context.Database.CommitTransactionAsync(cancellationToken) 
            : _context.Database.RollbackTransactionAsync(cancellationToken);

        return @task;
    }
}
