﻿using Microsoft.EntityFrameworkCore;
using Camera.MAUI;
using Microsoft.Extensions.Logging;
using EasyBarcodeMAU;

namespace EasyBarcodeMAUI {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            string connectionString = "Server=IST-010504-1134\\SQLEXPRESS;Database=DboUrunGirisCikis;Trusted_Connection=True;";
            builder.Services.AddDbContext<Infrastructure>(options =>
                options.UseSqlServer(connectionString));
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
