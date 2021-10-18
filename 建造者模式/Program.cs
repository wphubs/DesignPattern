using System;

namespace 建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            House house = GameManager.CreateHouse(new RomainHouseBuilder());
        }
    }

    //相当于director
    public class GameManager
    {
        //该构建过程是相对稳定才能用此模式
        public static House CreateHouse(Builder builder)
        {
            builder.BuildWindows();
            builder.BuildWindows();
            builder.BuildDoor();
            builder.BuildWall();
            return builder.GetHouse();
        }
    }
    //抽象类的实现，当变动时将RomainHouseBuilder和RomainHouse换成新的
    public class RomainHouse : House
    { }
    public class RomainHouseBuilder : Builder
    {
        public override void BuildWindows() { }
        public override void BuildDoor() { }
        public override void BuildWall() { }

        public override House GetHouse(){
            return new RomainHouse();
        }
    }

    //为了适应变化定义的抽象类
    public abstract class House
    { }
    public abstract class Builder
    {
        public abstract void BuildWindows();
        public abstract void BuildDoor();
        public abstract void BuildWall();

        public abstract House GetHouse();
    }
}
