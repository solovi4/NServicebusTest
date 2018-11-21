using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNservicebus
{
    class NServicebusManager
    {
        private EndpointConfiguration ConfigureEndpoint(string queue)
        {
            var endpointConfiguration = new EndpointConfiguration(queue);

            var persistence = endpointConfiguration.UsePersistence<NHibernatePersistence>();
            endpointConfiguration.UseSerialization<JsonSerializer>();
            var transport = endpointConfiguration.UseTransport<MsmqTransport>();
            var routing = transport.Routing();
            routing.RegisterPublisher(
                assembly: typeof(MyEvent).Assembly,
                publisherEndpoint: queue);

            endpointConfiguration.SendOnly();
            endpointConfiguration.EnableInstallers();


            return endpointConfiguration;
        }

        public async Task<IEndpointInstance> Start()
        {
            var config = ConfigureEndpoint("testproj.queue");
            return await Endpoint.Start(config).ConfigureAwait(false);
        }
    }
}
