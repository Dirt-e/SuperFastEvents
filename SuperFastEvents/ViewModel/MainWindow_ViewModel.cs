using SuperFastEvents.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace SuperFastEvents
{
    public class MainWindow_ViewModel : MyViewmodel
    {
        string _message = "193.7162, 0.6480, 212.2361, 212.2361, 0.0000, 0.0000, 571.2107, 0.0000, 4.9465, 0.0000,  1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0";
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("Message"); }
        }
        string _response = "";
        public string Response
        { 
            get { return _response; }
            set { _response = value; OnPropertyChanged("Response"); }
        }

        bool _btn_send_enabled = true;
        public bool Button_Send_Enabled
        {
            get { return _btn_send_enabled; }
            set { _btn_send_enabled = value; OnPropertyChanged("Button_Send_Enabled"); }
        }
        bool _btn_stop_enabled = false;
        public bool Button_Stop_Enabled
        {
            get { return _btn_stop_enabled; }
            set { _btn_stop_enabled = value; OnPropertyChanged("Button_Stop_Enabled"); }
        }
    }
}
