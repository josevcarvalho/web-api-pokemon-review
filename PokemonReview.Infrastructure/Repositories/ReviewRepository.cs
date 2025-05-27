using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Repositories;
using PokemonReview.Infrastructure.Database;

namespace PokemonReview.Infrastructure.Repositories
{
    public class ReviewRepository(DataContext context) : IReviewRepository
    {
        private readonly DataContext _context = context;

        public Task Create(Review entity, CancellationToken cancellationToken = default)
        {
            _context.Add(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        { 
            await _context.Reviews.Where(r => r.Id == id).ExecuteDeleteAsync(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> Exists(int id, CancellationToken cancellationToken = default)
        {
            return _context.Reviews.AnyAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<ICollection<Review>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Reviews.ToListAsync(cancellationToken);
        }

        public Task<Review> GetById(int id, CancellationToken cancellationToken = default)
        {
            return _context.Reviews.SingleAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<ICollection<Review>> GetReviewsOfAPokemon(int pokemonId, CancellationToken cancellationToken = default)
        {
            return await _context.Reviews.Where(r => r.Pokemon.Id == pokemonId).ToListAsync(cancellationToken);
        }

        public Task Update(Review entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
