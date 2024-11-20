using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desktop.cleardrive.desktop.services;
using Models;

namespace cleardrive.extensions
{
    public static class ApiServiceExtensions
    {
        public static void ConfigureApiServices(this IServiceCollection services)
        {
            services.AddScoped<IClearDriveDesktopService, ClearDriveDesktopService>();
        }
    }
}
