using PokemonReview.Domain.Entities;

namespace PokemonReview.Domain.Infrastructure.Repositories;

public interface IReviewerRepository : IRepositoryBase<Reviewer>
{
    Task<ICollection<Review>> GetReviewsByReviewer(int reviewerId, CancellationToken cancellationToken = default);
}
