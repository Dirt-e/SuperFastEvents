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
        MainWindow mainwindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        public void DoSomething()
        {
            //Do something here
        }

        public void MakeTheFirstClassDoSomething()
        {
            //Call a function on the "myfirstclass" object by accessing it through "mainwindow":
            mainwindow.myfirstclass.DoSomething();
        }
    }
}
