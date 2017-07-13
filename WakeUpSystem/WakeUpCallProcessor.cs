using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeUpSystem
{
    public class WakeUpCallProcessor : IWakeUpCallProcessor
    {
        private IAlarmSystem _alarmSystem;

        public WakeUpCallProcessor(IAlarmSystem alarmSystem)
        {
            _alarmSystem = alarmSystem;
        }

        public void ProcessWakeUpCalls()
        {
            WakeUp wakeup = null;

            while (true)
            {
                wakeup = _alarmSystem.GetNextCallRequest();
                if (wakeup == null)
                {
                    continue;
                }

                if (wakeup != null && wakeup.WakeUpTime.ToDateTimeFromEpoch() == DateTime.MinValue)
                {
                   continue;
                }

                if (Math.Abs(_alarmSystem.GetCurrentTime() - wakeup.WakeUpTime) <= 30)
                {
                    _alarmSystem.SendAlarmCall(wakeup.RoomNumber);
                }
                else
                {
                    _alarmSystem.AddBackToQueue(wakeup);
                }
            }
        }
    }
}
