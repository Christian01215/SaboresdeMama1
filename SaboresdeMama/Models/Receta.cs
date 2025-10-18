using SQLite;

namespace SaboresdeMama.Models
{
    [SQLite.Table("recetas")]
    public class Receta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public string Nombre { get; set; }

        // Guardaremos los ingredientes como un solo bloque de texto.
        // El usuario puede usar saltos de línea.
        public string Ingredientes { get; set; }

        public string Procedimiento { get; set; }
    }
}