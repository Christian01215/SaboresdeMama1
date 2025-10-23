using SaboresdeMama.Models;
using SaboresdeMama.Services;

namespace SaboresdeMama;

public partial class GestionPedidosPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public GestionPedidosPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;

        // ===============================================
        // ===== ESTA ES LA LÍNEA QUE AÑADIMOS =====
        // Bloquea el calendario para que no se puedan seleccionar fechas anteriores a hoy.
        FechaDatePicker.MinimumDate = DateTime.Today;
        // ===============================================
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadPedidosAsync();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        // Validación para el nombre del cliente
        if (string.IsNullOrWhiteSpace(ClienteNombreEntry.Text) ||
            string.IsNullOrWhiteSpace(DescripcionEntry.Text) ||
            string.IsNullOrWhiteSpace(TotalEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        var nuevoPedido = new Pedido
        {
            ClienteNombre = ClienteNombreEntry.Text,
            DescripcionProducto = DescripcionEntry.Text,
            FechaEntrega = FechaDatePicker.Date,
            Total = double.Parse(TotalEntry.Text),
            Estado = "Pendiente"
        };

        await _databaseService.AddPedidoAsync(nuevoPedido);

        ClienteNombreEntry.Text = string.Empty;
        DescripcionEntry.Text = string.Empty;
        TotalEntry.Text = string.Empty;
        FechaDatePicker.Date = DateTime.Now; // Resetea la fecha a hoy

        await LoadPedidosAsync();
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Pedido pedido)
        {
            bool confirmar = await DisplayAlert("Confirmar", $"¿Seguro que quieres eliminar el pedido '{pedido.DescripcionProducto}'?", "Sí", "No");
            if (confirmar)
            {
                await _databaseService.DeletePedidoAsync(pedido);
                await LoadPedidosAsync();
            }
        }
    }

    private async Task LoadPedidosAsync()
    {
        var pedidos = await _databaseService.GetPedidosAsync();
        PedidosCollectionView.ItemsSource = pedidos;
    }

    private async void OnCompletarClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Pedido pedido)
        {
            bool confirmar = await DisplayAlert("Confirmar Venta", $"¿Marcar el pedido '{pedido.DescripcionProducto}' como completado y mover a Ventas?", "Sí", "No");
            if (confirmar)
            {
                var nuevaVenta = new Venta
                {
                    ClienteNombre = pedido.ClienteNombre,
                    DescripcionProducto = pedido.DescripcionProducto,
                    Total = pedido.Total,
                    FechaCompletado = DateTime.Now
                };

                await _databaseService.AddVentaAsync(nuevaVenta);
                await _databaseService.DeletePedidoAsync(pedido);
                await LoadPedidosAsync();
            }
        }
    }
}