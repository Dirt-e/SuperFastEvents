using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperFastEvents.Model
{
    public class MySecondClass : MyObject
    {
        public MySecondClass(Model model)
        {
            Model = model;
        }

        public void DoSomething()
        {
            //Do something here
        }

        public void MakeTheFirstClassDoSomething()
        {
            Model.myfirstclass.DoSomething();
        }
    }
}
