using Microsoft.Extensions.Logging;
using SaboresdeMama;
using SaboresdeMama.Services;

namespace SaboresdeMama
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddTransient<GestionPedidosPage>();
            builder.Services.AddTransient<RecetarioPage>();
            builder.Services.AddTransient<AgregarRecetaPage>();
            builder.Services.AddTransient<RecetaDetallePage>();

            // ======================================================
            // ===== AÑADIR ESTA LÍNEA =====
            // ======================================================
            builder.Services.AddTransient<EditarRecetaPage>();

            return builder.Build();
        }
    }
}