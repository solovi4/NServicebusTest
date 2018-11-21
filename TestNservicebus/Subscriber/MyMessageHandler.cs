using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNservicebus;

namespace Subscriber
{
    class MyMessageHandler : IHandleMessages<MyEvent>
    {
        public Task Handle(MyEvent message, IMessageHandlerContext context)
        {
            PrintArr(message);
            return Task.FromResult(true);
        }

        private void PrintArr(MyEvent message)
        {
            foreach (var t in message.Arr)
            {
                Console.Write(t.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}
