
using Prueba.Application.UseCases;
using Prueba.Domain.Repositories;
using Prueba.Infrastructure.Repository;

namespace Prueba.Infrastructure.Conf
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Registrar servicios de la aplicación
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<CrearProducto>();
            services.AddScoped<ListarProductos>();
            services.AddScoped<ActualizarProducto>();
            services.AddScoped<ELiminarProducto>();
           
         }

    }
}
