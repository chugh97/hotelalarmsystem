using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WakeUpSystem
{
    public class AlarmSystem : IAlarmSystem, IQueueAlarm
    {
        private Queue<WakeUp> _wakeUpRequests;
        private DateTime? _now;
        private WakeUp _currentWakeUp;

        public AlarmSystem(Queue<WakeUp> wakeUpRequests, DateTime? now)
        {
            _wakeUpRequests = wakeUpRequests;
            _now = now;
        }

        public long GetCurrentTime()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var now = _now.HasValue ? _now.GetValueOrDefault() : DateTime.Now;
            return Convert.ToInt64((now - epoch).TotalSeconds);
        }

        public WakeUp GetNextCallRequest()
        {
            if (_wakeUpRequests == null)
            {
                return null;
            }

            if (_wakeUpRequests.Count == 0)
            {
                return null;
            }

            _currentWakeUp = _wakeUpRequests.Dequeue();
            return _currentWakeUp;
        }

        public void AddBackToQueue(WakeUp wakeup)
        {
            if (wakeup != null)
            {
                _wakeUpRequests.Enqueue(wakeup);
            }
        }

        public void SendAlarmCall(int roomNumber)
        {
            Console.WriteLine(string.Format("Please wake up! as this is your requested call for room number {0} at time {1}", roomNumber, _currentWakeUp.WakeUpTime.ToDateTimeFromEpoch()));
        }
    }
}
