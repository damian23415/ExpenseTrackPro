using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace ExpenseTrackPro.Infrastructure.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Określamy pełną ścieżkę do pliku appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Używamy DbContextOptionsBuilder, aby skonfigurować połączenie z bazą danych
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Tworzymy połączenie z bazą danych z użyciem connection string z appsettings.json
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Connection"));

            // Tworzymy i zwracamy instancję ApplicationDbContext z odpowiednimi ustawieniami
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}