using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace SuperFastEvents
{
    partial class MainWindow
    {
        public delegate void TimerEventHandler(UInt32 id, UInt32 msg, ref UInt32 userCtx, UInt32 rsv1, UInt32 rsv2);

        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeSetEvent")]
        static extern UInt32 timeSetEvent(UInt32 msDelay, UInt32 msResolution, TimerEventHandler handler, ref UInt32 userCtx, UInt32 eventType);

        [DllImport("winmm.dll", SetLastError = true)]
        static extern void timeKillEvent(UInt32 uTimerID);


        private UInt32 multimediaTimerID;

        private void TestMultimediaTimer()
        {
            UInt32 userCtx = 0;

            stopWatch = Stopwatch.StartNew();

            multimediaTimerID = timeSetEvent(
                1,
                0,
                new TimerEventHandler(TimerCallbackMethod),
                ref userCtx,
                1);
        }


        private void TimerCallbackMethod(uint id, uint msg, ref uint userCtx, uint rsv1, uint rsv2)
        {
            OnEventFired();

            eventsCount++;

            CheckTestFinished();
        }
    }
}
