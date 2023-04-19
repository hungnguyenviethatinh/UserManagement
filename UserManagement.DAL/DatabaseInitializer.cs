using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserManagement.DAL.Models;

namespace UserManagement.DAL
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        private ILogger _logger;

        public DatabaseInitializer(ApplicationDbContext dbContext, ILogger<DatabaseInitializer> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _dbContext.Database.MigrateAsync();

            if (!await _dbContext.Users.AnyAsync())
            {
                _logger.LogInformation("Generating inbuilt accounts...");

                var admin = new User
                {
                    UserName = "admin",
                    Password = "admin",
                    Name = "Admin",
                    Role = "admin",
                    Email = "admin@gmail.com",
                };

                await _dbContext.Users.AddAsync(admin);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Inbuilt account generation completed.");
            }
        }
    }
}
