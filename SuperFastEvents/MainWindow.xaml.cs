using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using SuperFastEvents.Model;

namespace SuperFastEvents
{
    public partial class MainWindow : Window
    {
        private MainWindow_ViewModel viewmodel = new MainWindow_ViewModel();
        private UdpClient UDP_Client;
        private BackgroundWorker backgroundworker;

        public MyFirstClass myfirstclass = new MyFirstClass();
        public MySecondClass mysecondclass = new MySecondClass();
        
        private int FromPort = 9999;
        private int ToPort = 10000;
        private string ToIP = "127.0.0.1";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewmodel;

            backgroundworker = new BackgroundWorker();
            backgroundworker.WorkerSupportsCancellation = true;

            UDP_Client = new UdpClient(FromPort);
        }

        private void StartBackgroundWorker()
        {
            if (backgroundworker.IsBusy) return;

            backgroundworker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                while (true)
                {
                    BusinessCycle();
                    UpdateViewmodel();

                    if (backgroundworker.CancellationPending) break;

                    Thread.Sleep(1);
                }
            };
            backgroundworker.RunWorkerAsync();
        }
        private void StopBackgroundWorker()
        {
            if (backgroundworker.IsBusy)
            {
                backgroundworker.CancelAsync();
            }

        }

        private void BusinessCycle()
        {
            byte[] bytes = Encoding.ASCII.GetBytes(viewmodel.Message);
            UDP_Client.Send(bytes, bytes.Length, ToIP, ToPort);
            //myfirstclass.MakeTheSecondClassDoSomething();
        }
        private void UpdateViewmodel()
        {   
            viewmodel.Response = "I have send: " + viewmodel.Message;
            
            Application.Current?.Dispatcher.Invoke(new Action(() =>
            {
                //Change Dependency Properties here
            }));

        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.Button_Send_Enabled = false;
            viewmodel.Button_Stop_Enabled = true;
            StartBackgroundWorker();
        }
        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.Button_Send_Enabled = true;
            viewmodel.Button_Stop_Enabled = false;
            StopBackgroundWorker();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            backgroundworker?.CancelAsync();
        }
    }
}
