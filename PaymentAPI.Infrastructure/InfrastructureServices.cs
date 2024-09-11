using Microsoft.Extensions.DependencyInjection;
using PaymentAPI.Domain.IRepository;
using PaymentAPI.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            return services;
        }
    }
}
