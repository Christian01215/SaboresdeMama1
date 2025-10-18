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
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadPedidosAsync();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(DescripcionEntry.Text) || string.IsNullOrWhiteSpace(TotalEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        var nuevoPedido = new Pedido
        {
            DescripcionProducto = DescripcionEntry.Text,
            FechaEntrega = FechaDatePicker.Date,
            Total = double.Parse(TotalEntry.Text),
            Estado = "Pendiente"
        };

        await _databaseService.AddPedidoAsync(nuevoPedido);

        // Limpiar los campos
        DescripcionEntry.Text = string.Empty;
        TotalEntry.Text = string.Empty;
        FechaDatePicker.Date = DateTime.Now;

        await LoadPedidosAsync();
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        // Obtener el pedido asociado al botón que se presionó
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
}