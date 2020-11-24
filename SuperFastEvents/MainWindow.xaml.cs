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
        private BackgroundWorker backgroundworker= new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
        private Model.Model Model = new Model.Model(); 

        private UdpClient UDP_Client;
        private int FromPort = 9999;
        private int ToPort = 31090;
        private string ToIP = "127.0.0.1";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = Model.mainwindow_viewmodel;

            backgroundworker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            

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

                    Thread.Sleep(4);
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
            byte[] bytes = Encoding.ASCII.GetBytes(Model.mainwindow_viewmodel.Message);
            UDP_Client.Send(bytes, bytes.Length, ToIP, ToPort);
            Model.myfirstclass.MakeTheSecondClassDoSomething();
            Model.mysecondclass.MakeTheFirstClassDoSomething();
        }
        private void UpdateViewmodel()
        {   
            Model.mainwindow_viewmodel.Response = "I have sent: " + Model.mainwindow_viewmodel.Message;
            
            Application.Current?.Dispatcher.Invoke(new Action(() =>
            {
                //Change Dependency Properties here
            }));

        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            Model.mainwindow_viewmodel.Button_Send_Enabled = false;
            Model.mainwindow_viewmodel.Button_Stop_Enabled = true;
            StartBackgroundWorker();
        }
        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            Model.mainwindow_viewmodel.Button_Send_Enabled = true;
            Model.mainwindow_viewmodel.Button_Stop_Enabled = false;
            StopBackgroundWorker();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            backgroundworker?.CancelAsync();
        }
    }
}
