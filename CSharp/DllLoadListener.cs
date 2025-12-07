using System;
using System.Diagnostics.Tracing;

namespace DefensiveMonitoring
{
    public class DllLoadListener : EventListener
    {
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            try
            {
                if (eventData.EventName == "ImageLoad" || eventData.EventName == "LoadImage")
                {
                    if (eventData.Payload != null && eventData.Payload.Count > 1)
                    {
                        string path = eventData.Payload[1]?.ToString();
                        Console.WriteLine($"[ETW] Image loaded: {path}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Listener exception: " + ex.Message);
            }
        }
    }
}