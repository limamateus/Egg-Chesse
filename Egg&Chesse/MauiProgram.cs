using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace Egg_Chesse
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Montserrat-ExtraBold.ttf", "MontserratExtraBold");
                    fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                    fonts.AddFont("Montserrat-Medium.ttf", "MontserratMedium");
                    fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
