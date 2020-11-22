using System.ComponentModel;
using System.Diagnostics;
using System.Threading;


namespace SuperFastEvents
{
    partial class MainWindow
    {
        private BackgroundWorker backgroundThread = new BackgroundWorker();
        private bool shouldStopCalls;


        private void TestSuccessiveCalls()
        {
            shouldStopCalls = false;

            backgroundThread.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                while (!shouldStopCalls)
                {
                    // Thread.Sleep(1);
                    PseudoDelay();

                    OnEventFired();

                    eventsCount++;

                    CheckTestFinished();
                }
            };

            stopWatch = Stopwatch.StartNew();

            backgroundThread.RunWorkerAsync();
        }


        private void PseudoDelay()
        {
            for (int i = 0; i < 200000; i++)
            {
            }
        }
    }
}
