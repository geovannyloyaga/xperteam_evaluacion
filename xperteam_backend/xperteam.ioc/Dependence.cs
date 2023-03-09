
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using xperteam.dal.DBContext;

using xperteam.dal.Repositories.Contract;
using xperteam.dal.Repositories;
using xperteam.utility;
using xperteam.bll.Services.Contract;
using xperteam.bll.Services;

namespace xperteam.ioc
{
    public static class Dependence
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<XperteamContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sql_string"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IGuideService, GuideService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
        }
    }
}
