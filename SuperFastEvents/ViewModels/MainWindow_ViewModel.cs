using System.ComponentModel;
using System.Windows;

namespace SuperFastEvents
{
    public class MainWindow_ViewModel : INotifyPropertyChanged
    {
        string _message = "";
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

        //INotifyPropertyChanged:
        public event PropertyChangedEventHandler PropertyChanged;
        private protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
