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

            // Hemos eliminado la sección de Logging que daba error.

            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddTransient<GestionPedidosPage>();

            return builder.Build();
        }
    }
}