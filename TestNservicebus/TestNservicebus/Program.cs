using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNservicebus
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();            
        }

        private static async Task MainAsync()
        {
            var nServicebusManager = new NServicebusManager();
            IEndpointInstance endpointInstance = await nServicebusManager.Start();
            var myEvent = new MyEvent { Arr = new short[] { 1, 3, 5 } };
            try
            {
                await endpointInstance.Publish(myEvent).ConfigureAwait(false);
            }
            catch (Exception e)
            {

            }
            finally
            {
                await endpointInstance.Stop().ConfigureAwait(false); ;
            }
        }
       
    }
}
