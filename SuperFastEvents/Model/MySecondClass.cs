using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperFastEvents.Model
{
    public class MySecondClass
    {
        public void DoSomething()
        {
            //Do something here
        }

        public void MakeTheFirstClassDoSomething()
        {
            //Call a function on the "myfirstclass" object by accessing it through "mainwindow":
            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().myfirstclass.DoSomething();
            /*PROBLEM:
            myfirstclass and mysecondclass both live inside Mainwindow and can only be accessed through mainwindow.
            However, the Mainwindow is running on the UI thread and can therfore not be reached from the BackgroundWorker
            because it would be a cross-thread operation.
            */
        }
    }
}
