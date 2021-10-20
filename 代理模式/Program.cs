using System;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject obj = new Proxy();
            obj.Request();
        }
    }

    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        public override void Request()
        {
            //业务方法具体实现代码
        }
    }

    public class Proxy : Subject
    {
        private RealSubject realSubject = new RealSubject(); //维持一个对真实主题对象的引用

        public void PreRequest()
        {
            //... ...
        }

        public override void Request()
        {
            PreRequest();
            realSubject.Request(); //调用真实主题对象的方法
            PostRequest();
        }

        public void PostRequest()
        {
            //... ...
        }
    }
}
