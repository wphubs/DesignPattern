using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    public class Baby : IObserver
    {
        public void Action()
        {
            this.Cry();
        }

        public void Cry()
        {
            Console.WriteLine("{0} Cry", this.GetType().Name);
        }
    }
}
