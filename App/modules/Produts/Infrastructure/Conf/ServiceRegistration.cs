
using Prueba.Application.UseCases;
using Prueba.Domain.Repositories;
using Prueba.Infraestructure.Repository;

namespace Prueba.Infraestructure.Conf
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
            services.AddScoped<ListarProductosPaginados>();
            services.AddScoped<ELiminarProducto>();
         }

    }
}
