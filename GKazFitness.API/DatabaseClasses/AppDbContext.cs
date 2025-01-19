using GKazFitness.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;



namespace GKazFitness.API.DatabaseClasses
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var userData = LoadJsonData<User>("Resources/User.json");
            modelBuilder.Entity<User>().HasData(userData);
        }

        private static List<T> LoadJsonData<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();

        }
    }
}
