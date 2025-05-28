using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Infrastructure.Repositories;
using PokemonReview.Infrastructure.Data;

namespace PokemonReview.Infrastructure.Repositories;

public class ReviewerRepository(DataContext context) : RepositoryBase<Reviewer>(context), IReviewerRepository
{
    public async Task<ICollection<Review>> GetReviewsByReviewer(int reviewerId, CancellationToken cancellationToken = default)
    {
        return await Context.Reviews
            .Where(r => r.ReviewerId == reviewerId)
            .ToListAsync(cancellationToken);
    }
}
