using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CryptoTop.Pages.Onboarding;
using CryptoTop.Services;
using DevExpress.Maui;

namespace CryptoTop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegistrationPage>();
            builder.Services.AddTransient<RegistrationViewModel>();


            builder.Services.AddSingleton<INavigationService, NavigationService>();

            return builder.Build();
        }
    }
}
