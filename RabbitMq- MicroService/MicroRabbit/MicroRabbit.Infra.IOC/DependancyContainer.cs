using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.DBContext;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IOC
{
    public class DependancyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
            //DOMAIN Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDBContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
