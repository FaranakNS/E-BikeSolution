using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReceivingSystem.BLL;
using ReceivingSystem.DAL;

namespace ReceivingSystem
{
    public static class ReceivingExtensions
    {
        public static void ReceivingSystemDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<EbikeContext>(options);

            services.AddTransient(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<EbikeContext>();
                return new OrderServices(context);
            });
        }
    }
}