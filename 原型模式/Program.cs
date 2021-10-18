using System;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSys sys = new GameSys();
            sys.Run(new NormalActorA(), new FlyActorA(), new WaterActorA());
        }
    }

    public class GameSys
    {
        public void Run(NormalActor normalActor, FlyActor flyActor, WaterActor waterActor)
        {
            NormalActor nActor1 = normalActor.Clone();
           
            NormalActor nActor2 = normalActor.Clone();
            NormalActor nActor3 = normalActor.Clone();

            FlyActor fActor1 = flyActor.Clone();
            FlyActor fActor2 = flyActor.Clone();
            WaterActor wActor1 = waterActor.Clone();
        }
    }
    #region 抽象类

    public abstract class NormalActor
    {
        public abstract NormalActor Clone();
    }
    public abstract class FlyActor
    {
        public abstract FlyActor Clone();
    }
    public abstract class WaterActor
    {
        public abstract WaterActor Clone();
    }
    #endregion

    #region 具体实现

    public class NormalActorA : NormalActor
    {
        public override NormalActor Clone()
        {
            //被拷贝对象成员不存在引用对象时使用，如果存在引用对象那么使用“深拷贝”
            return (NormalActor)this.MemberwiseClone();
        }
    }
    public class FlyActorA : FlyActor
    {
        public override FlyActor Clone()
        {
            return (FlyActor)this.MemberwiseClone();
        }
    }
    public class WaterActorA : WaterActor
    {
        public override WaterActor Clone()
        {
            return (WaterActor)this.MemberwiseClone();
        }
    }

    #endregion
}
