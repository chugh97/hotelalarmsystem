using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeUpSystem
{
    public static class SampleWakeUpCalls
    {
        // Times are Local Times
        public static Queue<WakeUp> CreateWakeupCalls()
        {
            Queue<WakeUp> wakeups = new Queue<WakeUp>();
            wakeups.Enqueue(new WakeUp() { RoomNumber = 10, WakeUpTime = DateTime.Today.AddHours(22).AddMinutes(28).AddSeconds(30).ToEpoch() });
            wakeups.Enqueue(new WakeUp() { RoomNumber = 2, WakeUpTime = DateTime.Today.AddDays(-1).AddHours(20).AddMinutes(39).AddSeconds(30).ToEpoch() });

            wakeups.Enqueue(new WakeUp() { RoomNumber = 1, WakeUpTime = DateTime.MinValue.ToEpoch() }); //No Alarm set
            wakeups.Enqueue(new WakeUp() { RoomNumber = 2, WakeUpTime = DateTime.Today.AddHours(22).AddMinutes(08).ToEpoch() });
            wakeups.Enqueue(new WakeUp() { RoomNumber = 3, WakeUpTime = DateTime.Now.AddMinutes(1).ToEpoch() });
            wakeups.Enqueue(new WakeUp() { RoomNumber = 4, WakeUpTime = DateTime.Now.AddMinutes(2).ToEpoch() });
            wakeups.Enqueue(new WakeUp() { RoomNumber = 5, WakeUpTime = DateTime.Now.AddMinutes(2).ToEpoch() });

            return wakeups;
        }
    }
}
