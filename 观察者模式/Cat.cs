using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao.....", this.GetType().Name);

            new Chicken().Woo();
            new Baby().Cry();
            new Dog().Wang();
        }

        private List<IObserver> _ObserverList = new List<IObserver>();
        public void AddObserver(IObserver observer)
        {
            this._ObserverList.Add(observer);
        }
        public void MiaoObserver()
        {
            Console.WriteLine("{0} MiaoObserver.....", this.GetType().Name);
            if (this._ObserverList != null && this._ObserverList.Count > 0)
            {
                foreach (var item in this._ObserverList)
                {
                    item.Action();
                }
            }
        }

        private event Action MiaoHandler;
        public void MiaoEvent()
        {
            Console.WriteLine("{0} MiaoEvent.....", this.GetType().Name);
            if (this.MiaoHandler != null)
            {
                foreach (Action item in this.MiaoHandler.GetInvocationList())
                {
                    item.Invoke();
                }
            }
        }
    }
}
