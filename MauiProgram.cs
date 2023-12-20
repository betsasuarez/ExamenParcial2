using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ExamenParcial2.Service;

namespace ExamenParcial2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Views.LoginPage>();
        builder.Services.AddSingleton<Views.EncuestaPage>();
        builder.Services.AddSingleton<ViewModel.LoginPageViewModel>();
        builder.Services.AddSingleton<ViewModel.EncuestaViewModel>();
        builder.Services.AddSingleton<Service.Interface.ILoginService, LoginService> ();
        builder.Services.AddSingleton<Service.Interface.IEncuestaService, EncuestaService> ();
        return builder.Build();
    }
}