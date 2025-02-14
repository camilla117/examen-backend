namespace MiCarrito.API.Dtos
{
    public class ArticulosDto
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public double Precio { get; set; }
        public required string Imagen { get; set; }
        public int Stock { get; set; }
    }
}
