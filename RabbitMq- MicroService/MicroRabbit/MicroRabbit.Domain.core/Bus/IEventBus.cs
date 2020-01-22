using MicroRabbit.Domain.core.Events;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Commands.Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>()
              where T : Event
              where TH : IEventHandler;
    }
}
