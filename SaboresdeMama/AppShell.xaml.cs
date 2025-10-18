namespace SaboresdeMama;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(GestionPedidosPage), typeof(GestionPedidosPage));
        Routing.RegisterRoute(nameof(RecetarioPage), typeof(RecetarioPage));
        Routing.RegisterRoute(nameof(AgregarRecetaPage), typeof(AgregarRecetaPage));
        Routing.RegisterRoute(nameof(RecetaDetallePage), typeof(RecetaDetallePage));
        Routing.RegisterRoute(nameof(EditarRecetaPage), typeof(EditarRecetaPage));

        // ======================================================
        // ===== AÑADIR ESTA LÍNEA =====
        // ======================================================
        Routing.RegisterRoute(nameof(VentasPage), typeof(VentasPage));
    }
}