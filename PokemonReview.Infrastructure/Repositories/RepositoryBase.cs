using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Infrastructure.Repositories;
using PokemonReview.Infrastructure.Data;

namespace PokemonReview.Infrastructure.Repositories;

public abstract class RepositoryBase<T>(DataContext context) : IRepositoryBase<T> where T : EntityBase
{
    protected readonly DataContext Context = context;

    public virtual async Task Create(T entity, CancellationToken cancellationToken = default)
    {
        await Context.AddAsync(entity, cancellationToken);
    }

    public virtual Task Delete(int id, CancellationToken cancellationToken = default)
    {
        return Context.Set<T>().Where(e => e.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    public virtual Task<bool> Exists(int id, CancellationToken cancellationToken = default)
    {
        return Context.Set<T>().AnyAsync(e => e.Id == id, cancellationToken);
    }

    public virtual async Task<ICollection<T>> GetAll(CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }

    public virtual Task<T> GetById(int id, CancellationToken cancellationToken = default)
    {
        return Context.Set<T>().SingleAsync(e => e.Id == id, cancellationToken);
    }

    public virtual Task Update(T entity, CancellationToken cancellationToken = default)
    {
        Context.Update(entity);
        return Task.CompletedTask;
    }
}
