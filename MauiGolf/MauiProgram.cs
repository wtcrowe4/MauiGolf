using Microsoft.Extensions.Logging;
using MauiGolf.Pages;
using MauiGolf.Models;
using MauiGolf.ViewModels;

namespace MauiGolf
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

#if DEBUG
		builder.Logging.AddDebug();
#endif
            
            builder.Services.AddSingleton<AuthAppShell>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<ScoresPage>();
            builder.Services.AddSingleton<User>();

            //Database
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauigolf.db3");
            builder.Services.AddSingleton<Data.Database>();
            
            return builder.Build();
        }
    }
}