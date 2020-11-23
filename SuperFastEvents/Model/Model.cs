using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFastEvents.Model
{
    public class Model
    {
        public MainWindow_ViewModel mainwindow_viewmodel = new MainWindow_ViewModel();
        //QUESTION: Where should I instatiate the MainWindow_ViewModel object, so that other objects can update it when something changes?

        public MyFirstClass myfirstclass;
        public MySecondClass mysecondclass;

        public int FromPort = 9999;
        public int ToPort = 10000;
        public string ToIP = "127.0.0.1";

        public Model()
        {
            myfirstclass = new MyFirstClass(this);
            mysecondclass = new MySecondClass(this);
        }
    }
}
