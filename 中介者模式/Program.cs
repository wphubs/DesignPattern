using System;

namespace 中介者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractCardPlayer a = new PlayerA() { MoneyCount = 20 };
            AbstractCardPlayer b = new PlayerB() { MoneyCount = 20 };
            AbstractMediator mediator = new Mediator(a, b);
            //玩家a赢了玩家b 5元
            Console.WriteLine("a赢了b5元");
            a.ChangeCount(5, mediator);
            Console.WriteLine($"玩家a现在有{a.MoneyCount}元");
            Console.WriteLine($"玩家b现在有{b.MoneyCount}元");
            //玩家b赢了玩家a 10元
            Console.WriteLine("b赢了a10元");
            b.ChangeCount(10, mediator);
            Console.WriteLine($"玩家a现在有{a.MoneyCount}元");
            Console.WriteLine($"玩家b现在有{b.MoneyCount}元");
            Console.ReadKey();
        }
    }

    //抽象玩家类
    public abstract class AbstractCardPlayer
    {
        public int MoneyCount { get; set; }
        public AbstractCardPlayer()
        {
            this.MoneyCount = 0;
        }
        public abstract void ChangeCount(int count, AbstractMediator mediator);
    }
    //玩家A类
    public class PlayerA : AbstractCardPlayer
    {
        //通过中介者来算账，不用直接找输家了
        public override void ChangeCount(int count, AbstractMediator mediator)
        {
            mediator.AWin(count);
        }
    }
    //玩家B类
    public class PlayerB : AbstractCardPlayer
    {
        public override void ChangeCount(int count, AbstractMediator mediator)
        {
            mediator.BWin(count);
        }
    }
    //抽象中介者
    public abstract class AbstractMediator
    {
        //中介者必须知道所有同事
        public AbstractCardPlayer A;
        public AbstractCardPlayer B;
        public AbstractMediator(AbstractCardPlayer a, AbstractCardPlayer b)
        {
            A = a;
            B = b;
        }
        public abstract void AWin(int count);
        public abstract void BWin(int count);
    }
    //具体中介者
    public class Mediator : AbstractMediator
    {
        public Mediator(AbstractCardPlayer a, AbstractCardPlayer b) : base(a, b) { }
        public override void AWin(int count)
        {
            A.MoneyCount += count;
            B.MoneyCount -= count;
        }
        public override void BWin(int count)
        {
            A.MoneyCount -= count;
            B.MoneyCount += count;
        }
    }
}
