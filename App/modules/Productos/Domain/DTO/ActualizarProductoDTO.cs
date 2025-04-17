namespace Prueba.Domain.DTO
{
    public record ActualizarProductoDTO
    (
        int Id,
        string? Nombre,
        double Precio,        
        int Stock,
        DateTime? FechaIngreso,
        int BodegaId
    );
}