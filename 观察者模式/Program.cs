using System;

namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************Observer******************");
            Cat cat = new Cat();
            cat.AddObserver(new Chicken());
            cat.AddObserver(new Baby());
            cat.AddObserver(new Dog());
            cat.MiaoObserver();

            Console.ReadKey();
        }
    }
}
