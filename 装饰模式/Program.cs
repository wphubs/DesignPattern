using System;

namespace 装饰模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new BigHero();
            HeroShell s1 = new SpiderManShell(hero);
            HeroShell s2 = new SupperManShell(s1);
            s2.Attack();
            Console.ReadKey();
        }
    }
    //Component
    public abstract class Hero
    {
        public abstract void Attack();
    }
    //Decorator
    public abstract class HeroShell : Hero
    {
        private Hero _hero;

        public HeroShell(Hero hero)
        {
            _hero = hero;
        }

        public override void Attack()
        {
            _hero.Attack();
        }
    }

    //ConcreteDecoratorA
    public class SpiderManShell : HeroShell
    {
        public SpiderManShell(Hero hero) : base(hero) { }
        public override void Attack()
        {
            Console.WriteLine("织网");
            Console.WriteLine("撒网");
            base.Attack();
        }
    }
    //ConcreteDecoratorB
    public class SupperManShell : HeroShell
    {
        public SupperManShell(Hero hero) : base(hero) { }
        public override void Attack()
        {
            Console.WriteLine("我飞");
            Console.WriteLine("我裤衩反穿");
            base.Attack();
        }
    }

    //ConcreteComponent
    public class BigHero : Hero
    {

        public override void Attack()
        {
            Console.WriteLine("我是破坏者，BigHero");
        }
    }
}
