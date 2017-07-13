using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeUpSystem
{
    public interface IAlarmSystem : IQueueAlarm
    {
        void SendAlarmCall(int roomNumber);

        WakeUp GetNextCallRequest();

        long GetCurrentTime();
    }

}
