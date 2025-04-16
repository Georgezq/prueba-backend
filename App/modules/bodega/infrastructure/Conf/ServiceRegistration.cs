
using Prueba.Application.UseCases;
using Prueba.Domain.Repositories;
using Prueba.Infraestructure.Repository;

namespace Prueba.Infraestructure.Confi
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServicesBodega(this IServiceCollection services)
        {
            // Registrar servicios de la aplicación
            services.AddScoped<IBodegaRepository, BodegaRepository>();
            services.AddScoped<CrearBodega>();
            services.AddScoped<ListarBodegas>();
            services.AddScoped<ListarBodegasPaginacion>();
            services.AddScoped<ActualizarBodega>();
            services.AddScoped<EliminarBodega>();
         }

    }
}
