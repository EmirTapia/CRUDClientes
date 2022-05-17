namespace OneCore.API.DataModels
{
    public class Producto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public string Descripcion { get; set; }

        public int ClienteId { get; set; }
    }
}
