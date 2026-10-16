using InterviewProject2.Data;
using InterviewProject2.Repositories.Implementations;
using InterviewProject2.Repositories.Interfaces;
using InterviewProject2.Services.Implementations;
using InterviewProject2.Services.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = new SqliteConnection("Data Source=:memory:");
await connection.OpenAsync();

builder.Services.AddSingleton(connection);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connection));

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    await dbContext.Database.EnsureCreatedAsync();

}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();