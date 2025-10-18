using SQLite;

namespace SaboresdeMama.Models
{
    [SQLite.Table("ventas")]
    public class Venta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DescripcionProducto { get; set; }

        public double Total { get; set; }

        // Guardamos la fecha en que se completó la venta
        public DateTime FechaCompletado { get; set; }
    }
}