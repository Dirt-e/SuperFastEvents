using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Windows;


namespace SuperFastEvents
{
    public partial class MainWindow : Window
    {
        private MainWindow_ViewModel viewmodel = new MainWindow_ViewModel();
        private UdpClient UDP_Client;

        private int FromPort = 9999;
        private int ToPort = 10000;
        private string ToIP = "127.0.0.1";

        private Stopwatch stopWatch;
        private int eventsCount;


        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewmodel;

            viewmodel.Message = "Test";
            viewmodel.TestDispatcherTimer = true;
            viewmodel.IsTestIdle = true;

            UDP_Client = new UdpClient(FromPort);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.IsTestIdle = false;
            eventsCount = 0;

            if (viewmodel.TestDispatcherTimer)
            {
                TestDispatcherTimer();
            }
            else if (viewmodel.TestMultimediaTimer)
            {
                TestMultimediaTimer();
            }
            else
            {
                TestSuccessiveCalls();
            }
        }


        private void OnEventFired()
        {
            byte[] bytes = Encoding.ASCII.GetBytes(viewmodel.Message);
            UDP_Client.Send(bytes, bytes.Length, ToIP, ToPort);
        }

        private void CheckTestFinished()
        {
            return;
            if (eventsCount == 1000)
            {
                if (viewmodel.TestDispatcherTimer)
                {
                    dispatcherTimer.IsEnabled = false;
                }
                else if (viewmodel.TestMultimediaTimer)
                {
                    timeKillEvent(multimediaTimerID);
                }
                else
                {
                    shouldStopCalls = true;
                }

                stopWatch.Stop();

                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    ReportTestFinished();
                }));
            }
        }


        private void ReportTestFinished()
        {
            MessageBox.Show(
                string.Format("Time taken for {0} events: {1}ms \nEvents per second: {2} \n{3}ms per event",
                eventsCount,
                stopWatch.Elapsed.TotalMilliseconds,
                eventsCount * 1000 / stopWatch.Elapsed.TotalMilliseconds,
                stopWatch.Elapsed.TotalMilliseconds / eventsCount));

            viewmodel.IsTestIdle = true;
        }
    }
}
