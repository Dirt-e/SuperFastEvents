using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFastEvents.Model
{
    public class _Model
    {
        public MyFirstClass myfirstclass;
        public MySecondClass mysecondclass;

        public int FromPort = 9999;
        public int ToPort = 10000;
        public string ToIP = "127.0.0.1";

        public _Model()
        {
            myfirstclass = new MyFirstClass(this);
            mysecondclass = new MySecondClass(this);
        }
    }
}
