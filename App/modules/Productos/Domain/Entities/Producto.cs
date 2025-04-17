namespace Prueba.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int BodegaId { get; set; }
    }
}