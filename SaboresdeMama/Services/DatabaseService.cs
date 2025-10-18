using SQLite;
using SaboresdeMama.Models;

namespace SaboresdeMama.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;
        private bool _initialized = false;

        public DatabaseService()
        {
            // La inicialización se hará de forma asíncrona
        }

        private async Task InitializeAsync()
        {
            if (_initialized)
                return;

            // Ruta donde se guardará el archivo de la base de datos en el dispositivo
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "SaboresdeMama.db3");

            // Crear la conexión y la tabla si no existen
            _database = new SQLiteAsyncConnection(databasePath);
            await _database.CreateTableAsync<Pedido>();

            _initialized = true;
        }

        // --- Operaciones CRUD (Crear, Leer, Actualizar, Borrar) ---

        public async Task<List<Pedido>> GetPedidosAsync()
        {
            await InitializeAsync();
            return await _database.Table<Pedido>().OrderBy(p => p.FechaEntrega).ToListAsync();
        }

        public async Task AddPedidoAsync(Pedido pedido)
        {
            await InitializeAsync();
            await _database.InsertAsync(pedido);
        }

        public async Task DeletePedidoAsync(Pedido pedido)
        {
            await InitializeAsync();
            await _database.DeleteAsync(pedido);
        }
    }
}