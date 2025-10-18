using SQLite;

namespace SaboresdeMama.Models
{
    [SQLite.Table("pedidos")]
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200), Indexed]
        public string DescripcionProducto { get; set; }

        public DateTime FechaEntrega { get; set; }

        public string Estado { get; set; } // Pendiente, Entregado, Cancelado

        public double Total { get; set; }
    }
}