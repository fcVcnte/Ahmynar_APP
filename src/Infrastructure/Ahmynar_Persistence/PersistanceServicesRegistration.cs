using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.Contracts.Persistence.Common;
using Ahmynar_Persistence.Repositories;
using Ahmynar_Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Persistence
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AhmynarDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AhmynarConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEquipamentRepository, EquipamentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            return services;
        }
    }
}
