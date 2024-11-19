//using Microsoft.Extensions.DependencyInjection;
using cleardrive.desktop;
using cleardrive.desktop.viewmodel;
//using desktop.cleardrive.desktop.view;
using Models;

namespace Extensions
{
    public static class ViewViewModelsExtensions
    {
        public static void ConfigureViewViewModels(this IServiceCollection services)
        {
            // MainView
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                BindingContext = s.GetRequiredService<MainViewModel>()
            });
        }
    }
}
