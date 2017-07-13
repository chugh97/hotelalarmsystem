using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WakeUpSystem;

namespace HotelAlarmWakeUpSystem
{
    class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = false;                
            };

            Console.WriteLine("Welcome to the Hotel Alarm System");
            Console.WriteLine("=================================================================================");
            Console.WriteLine("To EXIT program press Control + C");
            try
            {
                AlarmSystem alarmSystem = new AlarmSystem(SampleWakeUpCalls.CreateWakeupCalls(), null);
                WakeUpCallProcessor wakeupCallProcessor = new WakeUpCallProcessor(alarmSystem);
                wakeupCallProcessor.ProcessWakeUpCalls();
                _quitEvent.WaitOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops something has not worked!");
            }
            
        }
    }
}
