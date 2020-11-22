using System.Windows;

namespace SuperFastEvents
{
    public class MainWindow_ViewModel: DependencyObject
    {
        public string Message { get; set; } 
        public bool TestDispatcherTimer { get; set; }
        public bool TestMultimediaTimer { get; set; }
        public bool TestSuccessiveCalls { get; set; }

        public static readonly DependencyProperty IsTestIdleProperty = DependencyProperty.Register("IsTestIdle", typeof(bool), typeof(MainWindow_ViewModel));
        public bool IsTestIdle
        {
            get { return (bool)GetValue(IsTestIdleProperty); }
            set { SetValue(IsTestIdleProperty, value); }
        }
    }
}
