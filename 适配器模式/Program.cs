using System;

namespace 适配器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 对客户端来说，调用的就是Target的Request()
            Target target = new Adapter();
            target.Request();

        }
    }

    /// <summary>
    /// 定义客户端期待的接口
    /// </summary>
    public class Target
    {
        /// <summary>
        /// 使用virtual修饰以便子类可以重写
        /// </summary>
        public virtual void Request()
        {
            Console.WriteLine("This is a common request");
        }
    }


    /// <summary>
    /// 定义需要适配的类
    /// </summary>
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("This is a special request.");
        }
    }


    /// <summary>
    /// 定义适配器
    /// </summary>
    public class Adapter : Target
    {
        // 建立一个私有的Adeptee对象
        private Adaptee adaptee = new Adaptee();

        /// <summary>
        /// 通过重写，表面上调用Request()方法，变成了实际调用SpecificRequest()
        /// </summary>
        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}
