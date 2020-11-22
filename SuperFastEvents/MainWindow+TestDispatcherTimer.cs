using System;
using System.Diagnostics;
using System.Windows.Threading;


namespace SuperFastEvents
{
    partial class MainWindow
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private void TestDispatcherTimer()
        {
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Tick += (object sender, EventArgs e) =>
                {
                    OnEventFired();

                    eventsCount++;

                    CheckTestFinished();
                };

            stopWatch = Stopwatch.StartNew();

            dispatcherTimer.IsEnabled = true;
        }
    }
}
