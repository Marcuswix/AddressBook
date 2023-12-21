using AddressBookMaui.Pages;
using AddressBookMaui.ViewModels;
using Microsoft.Extensions.Logging;
using Shared.Services;

namespace AddressBookMaui
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

            builder.Services.AddSingleton<ContactAddPage>();
            builder.Services.AddSingleton<ContactListPage>();  
            builder.Services.AddSingleton<ContactListViewModel>();
            builder.Services.AddSingleton<ContactAddViewModel>(); 
            builder.Services.AddSingleton<ContactDetailsPage>();
            builder.Services.AddSingleton<ContactDetailsViewModel>();
            builder.Services.AddSingleton<ContactServices>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
