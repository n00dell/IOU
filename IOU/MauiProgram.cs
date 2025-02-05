using IOU.Services.Implementations;
using IOU.Services.Interfaces;
using IOU.ViewModels;
using IOU.Views;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.Extensions.Http;


namespace IOU
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
           builder.Services.AddSingleton<Login>();
           builder.Services.AddSingleton<DashboardPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<IRegistrationService, RegistrationService>();
            builder.Services.AddTransient<SignUpPageViewModel>();
            builder.Services.AddTransient<SignUp>();

            
#if DEBUG
            builder.Logging.AddDebug();
#endif
            IServiceCollection services = builder.Services;

            services.AddSerilog(new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.File(Path.Combine(FileSystem.Current.AppDataDirectory, "log.txt"))
                .CreateLogger());
            builder.Services.AddHttpClient<IRegistrationService, RegistrationService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7010/");
            });
            return builder.Build();
        }
    }
}
