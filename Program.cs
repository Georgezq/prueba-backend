using Microsoft.EntityFrameworkCore;
using Prueba.Shared.Data;
using Prueba.Infraestructure.Conf;
using Prueba.Infraestructure.Confi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddApplicationServicesBodega();
builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddPolicy("AllowAngular", policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductosDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();
app.Run();
