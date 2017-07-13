Hotel Alarm System

Open File SampleWakeUpCalls.cs 

I have added a few alarms just 1,2 minutes from the moment you run the program.
If you wish you can add more alarms in local time

wakeups.Enqueue(new WakeUp() { RoomNumber = 99, WakeUpTime = DateTime.Today.AddHours(13).AddMinutes(2).ToEpoch() });

This sets alarm for room no 99 at 13:02 Hrs (1:02PM) Local Time which at the moment is BST.

Run the HotelAlarmWakeUpSystem - Console project (exe)

When the alarms in the file match the actual time defined in the above file you will see a console message
saying "Please wake up! as this is your requested call for room number 99 at time DD/MM/YYYY 13:02", where DD/MM/YYYY is the today (13/07/2017) for e.g.

To Exit the program -Press Contrl + C key to exit the application.

This is a continous polling application which runs as an enless loop till exited. When current times matched it prints the message for the respective room number.

I have deliberately added a nullable DateTime parameter in the constructor of the AlarmSystem. class

 AlarmSystem(Queue<WakeUp> wakeUpRequests, DateTime? now)

 So by default I pass null which gets the current datetime. For increase testability we can pass a fake datetime now to get unit tests for the classes.

 As this was a small 30 mins exercise I have not written tests but a few alaram cases are included to cover the requirements.
