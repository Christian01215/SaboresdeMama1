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
        }

        private async Task InitializeAsync()
        {
            if (_initialized)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "SaboresdeMama.db3");
            _database = new SQLiteAsyncConnection(databasePath);

            // Creamos las tres tablas
            await _database.CreateTableAsync<Pedido>();
            await _database.CreateTableAsync<Receta>();
            await _database.CreateTableAsync<Venta>(); // <-- NUEVA TABLA

            _initialized = true;
        }

        // --- Operaciones de Pedidos ---
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

        // --- Operaciones de Recetas ---
        // (Aquí va todo tu código de AddRecetaAsync, GetRecetasAsync, SearchRecetasAsync, DeleteRecetaAsync, UpdateRecetaAsync)
        public async Task AddRecetaAsync(Receta receta)
        {
            await InitializeAsync();
            await _database.InsertAsync(receta);
        }
        public async Task<List<Receta>> GetRecetasAsync()
        {
            await InitializeAsync();
            return await _database.Table<Receta>().OrderBy(r => r.Nombre).ToListAsync();
        }
        public async Task<List<Receta>> SearchRecetasAsync(string searchTerm)
        {
            await InitializeAsync();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetRecetasAsync();
            }
            return await _database.Table<Receta>()
                .Where(r => r.Nombre.ToLower().Contains(searchTerm.ToLower()))
                .ToListAsync();
        }
        public async Task DeleteRecetaAsync(Receta receta)
        {
            await InitializeAsync();
            await _database.DeleteAsync(receta);
        }
        public async Task UpdateRecetaAsync(Receta receta)
        {
            await InitializeAsync();
            await _database.UpdateAsync(receta);
        }

        // ===============================================
        // ===== NUEVOS MÉTODOS PARA GESTIÓN DE VENTAS =====
        // ===============================================

        public async Task AddVentaAsync(Venta venta)
        {
            await InitializeAsync();
            await _database.InsertAsync(venta);
        }

        public async Task<List<Venta>> GetVentasAsync()
        {
            await InitializeAsync();
            // Las ordenamos por fecha, de la más nueva a la más antigua
            return await _database.Table<Venta>().OrderByDescending(v => v.FechaCompletado).ToListAsync();
        }

        public async Task DeleteVentaAsync(Venta venta)
        {
            await InitializeAsync();
            await _database.DeleteAsync(venta);
        }
    }
}