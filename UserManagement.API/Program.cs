using Microsoft.EntityFrameworkCore;
using UserManagement.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"],
        b => b.MigrationsAssembly("UserManagement.API"));
});

builder.Services.AddLogging();

builder.Services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var databaseInitializer = services.GetRequiredService<IDatabaseInitializer>();
    databaseInitializer.SeedAsync().Wait();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Error on initializing database.");
}

app.Run();
