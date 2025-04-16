namespace Prueba.Domain.Entities
{
    public class Bodega
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<Producto>? Producto { get; set; }
    }
}