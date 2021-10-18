using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 单例模式
{
    public class Singleton
    {

   

        //volatile 它是被设计用来修饰被不同线程访问和修改的变量。
        //如果没有volatile，基本上会导致这样的结果：
        //要么无法编写多线程程序，要么编译器失去大量优化的机会。
        //volatile的作用： 作为指令关键字，确保本条指令不会因编译器的优化而省略，且要求每次直接读值.
        private static volatile Singleton instance = null;

        private static object lockHelper = new object();
        //取消默认的public的构造器
        private Singleton() { }
        //实例的出口
        public static Singleton Instance
        {
            get
            {
                //double check 前面的判断是为了减少后面判断的访问，因为后面的判断会阻塞并发线程
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
