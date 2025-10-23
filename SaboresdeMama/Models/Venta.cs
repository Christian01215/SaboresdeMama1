using SQLite;

namespace SaboresdeMama.Models
{
    [SQLite.Table("ventas")]
    public class Venta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DescripcionProducto { get; set; }

        // ===================================
        // ===== NUEVA PROPIEDAD AÑADIDA =====
        public string ClienteNombre { get; set; }
        // ===================================

        public double Total { get; set; }

        public DateTime FechaCompletado { get; set; }
    }
}