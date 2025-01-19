using Microsoft.EntityFrameworkCore;



namespace GKazFitness.API.DatabaseClasses

{
    public static class ConnectionService
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("GKazFitnessDB")));

            return services;
        }
    }
}
