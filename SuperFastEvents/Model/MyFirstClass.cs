using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperFastEvents.Model
{
    public class MyFirstClass : MyObject
    {
        public MyFirstClass(Model model)
        {
            Model = model;
        }

        public void DoSomething()
        {
            //Change the message:
            Application.Current?.Dispatcher.Invoke(new Action(() =>
            {
                Model.mainwindow_viewmodel.Response = "I have sent: " + Model.mainwindow_viewmodel.Message;

            }));

        }

        public void MakeTheSecondClassDoSomething()
        {
            Model.mysecondclass.DoSomething();
        }
    }
}
