using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ServicingSystem.DAL;
using ServicingSystem.BLL;
#endregion

namespace ServicingSystem
{
    public static class ServicingExtensions
    {
        public static void ServicingSystemDependencies
            (this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<EbikeContext>(options);

            services.AddTransient<CustomerServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<EbikeContext>();
                return new CustomerServices(context);
            });

            services.AddTransient<CustomerVehicleServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<EbikeContext>();
                return new CustomerVehicleServices(context);
            });

            services.AddTransient<StandardServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<EbikeContext>();
                return new StandardServices(context);
            });

            services.AddTransient<CouponServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<EbikeContext>();
                return new CouponServices(context);
            });

            services.AddTransient<JobServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<EbikeContext>();
                return new JobServices(context);
            });

        }
    }
}
