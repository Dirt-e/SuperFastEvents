using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperFastEvents.Model
{
    public class MyFirstClass
    {
        MainWindow mainwindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        public void DoSomething()
        {
            //Do something here
        }

        public void MakeTheSecondClassDoSomething()
        {
            //Call a function on the "otherclass" object by accessing it through "mainwindow":
            mainwindow.mysecondclass.DoSomething();
        }
    }
}
