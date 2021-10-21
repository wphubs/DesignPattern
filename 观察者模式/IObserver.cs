using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{
    /// <summary>
    /// 只是为了把多个对象产生关系，方便保存和调用
    /// 方法本身其实没用
    /// </summary>
    public interface IObserver
    {
        void Action();
    }

}
