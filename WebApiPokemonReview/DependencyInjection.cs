using System.Text.Json.Serialization;

namespace PokemonReview.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        return services
            .AddAppControllers()
            .AddEndpoints()
            .AddSwagger();
    }

    private static IServiceCollection AddAppControllers(this IServiceCollection services)
    {
        return services.AddControllers()
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
            .Services;
    }

    private static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        return services.AddEndpointsApiExplorer();
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        return services.AddSwaggerGen();
    }
}
