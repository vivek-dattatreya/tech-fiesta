using MicroRabbit.Domain.core.Events;
using System;

namespace MicroRabbit.Domain.core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; protected set; }

        protected Command()
        {

            TimeStamp = DateTime.Now;
         
        }
          
        
        
    }
}
