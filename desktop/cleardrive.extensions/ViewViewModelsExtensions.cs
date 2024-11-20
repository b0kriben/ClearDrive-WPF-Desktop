using Microsoft.Extensions.DependencyInjection;
using desktop.cleardrive.desktop;
using cleardrive.desktop.viewmodel;
using Models;

namespace cleardrive.extensions
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
            /*Összegzés
            A MainWindow osztály aláhúzása a következőket jelezheti:

            1. Hiányzó using cleardrive.desktop; direktíva.
            2. A MainWindow osztály nincs megfelelően implementálva vagy nem elérhető a kódban.
            3. A DataContext nem megfelelő beállítása (használja a DataContext = ... helyett a BindingContext-ot).
            4. A partial kulcsszó hiánya a MainWindow osztályban.

            Győződjön meg arról, hogy a fenti dolgok mind rendben vannak, és a projekt megfelelően van beállítva. 
            Ha bármelyik fenti dolog hiányzik vagy hibás, az okozhatja, hogy a MainWindow osztály nem elérhető 
            a ConfigureViewViewModels metódusban.*/
        }
    }
}
