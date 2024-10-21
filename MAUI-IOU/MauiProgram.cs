using MAUI_IOU.Models;
using MAUI_IOU.Services.Implementations;
using MAUI_IOU.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace MAUI_IOU
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
            builder.Services.AddScoped<IInterestCalculationService, InterestCalculationService>();
            builder.Services.AddScoped<ILateFeeService, LateFeeService>();
            builder.Services.AddScoped<IPaymentProcessingService, PaymentProcessingService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
