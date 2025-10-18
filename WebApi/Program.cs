using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Postgres config
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))); //Todo: add conexion to bd in appsettings.json

// Redis config
var redisUrl = builder.Configuration["RedisConnection"]; //Todo: add conexion to cache in appsettings.json
if (!string.IsNullOrEmpty(redisUrl))
{
    builder.Services.AddSingleton<IConnectionMultiplexer>(
        ConnectionMultiplexer.Connect(redisUrl));
}

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
