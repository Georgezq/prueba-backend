using Microsoft.EntityFrameworkCore;
using Prueba.Shared.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductosDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();


app.UseHttpsRedirection();

app.Run();