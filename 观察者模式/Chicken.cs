using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    public class Chicken : IObserver
    {
        public void Action()
        {
            this.Woo();
        }
        public void Woo()
        {
            Console.WriteLine("{0} Woo", this.GetType().Name);
        }
    }
}
