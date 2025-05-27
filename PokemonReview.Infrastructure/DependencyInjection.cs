using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokemonReview.Domain.Repositories;
using PokemonReview.Infrastructure.Database;
using PokemonReview.Infrastructure.Repositories;

namespace PokemonReview.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services.AddDatabase().AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReviewRepository, ReviewRepository>();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>(options =>
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projetos\db\pokemon-review.mdf;Integrated Security=True;Connect Timeout=30";
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
