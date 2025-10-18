namespace SaboresdeMama;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Esta es la línea que agregamos para la navegación
        Routing.RegisterRoute(nameof(GestionPedidosPage), typeof(GestionPedidosPage));
    }
}