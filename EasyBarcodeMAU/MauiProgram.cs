using Camera.MAUI;
using Microsoft.Extensions.Logging;
//using ZXing.Net.Maui.Controls;

namespace EasyBarcodeMAU {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCameraView() 
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

		builder.Logging.AddDebug();

            return builder.Build();
        }
    }
}