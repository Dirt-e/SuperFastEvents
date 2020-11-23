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
        public MyFirstClass(_Model model)
        {
            Model = model;
        }

        public void DoSomething()
        {
            
        }

        public void MakeTheSecondClassDoSomething()
        {
            Model.mysecondclass.DoSomething();
        }
    }
}
