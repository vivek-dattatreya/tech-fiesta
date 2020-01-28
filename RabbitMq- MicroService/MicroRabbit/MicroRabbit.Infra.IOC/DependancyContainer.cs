using MicroRabbit.Domain.core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Infra.IOC
{
    public class DependancyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
