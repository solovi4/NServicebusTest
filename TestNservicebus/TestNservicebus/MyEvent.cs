using NServiceBus;


namespace TestNservicebus
{
    public class MyEvent : IEvent
    {
        public short[] Arr;
    }
}
