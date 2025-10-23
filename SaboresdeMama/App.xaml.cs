using System.Globalization; // <-- 1. AÑADE ESTA LÍNEA ARRIBA

namespace SaboresdeMama;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // ======================================================
        // ===== AÑADE ESTAS DOS LÍNEAS PARA FORZAR ESPAÑOL =====
        // Usamos "es-CL" para español de Chile.
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-CL");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-CL");
        // ======================================================

        MainPage = new AppShell();
    }
}