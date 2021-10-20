using System;
using System.Collections.Generic;

namespace 享元模式
{
    class Program
    {
        static void Main(string[] args)
        {
            CarFactory carFactory = new CarFactory();

            //小头爸爸开蓝色的车
            Driver d1 = new Driver("小头爸爸");
            Car c1 = carFactory.GetCar("蓝色");
            c1.Use(d1);

            //扁头妈妈开蓝色的车
            Driver d2 = new Driver("扁头妈妈");
            Car c2 = carFactory.GetCar("蓝色");
            c2.Use(d2);

            if (c1.Equals(c2))
            {
                Console.WriteLine("小头爸爸和扁头妈妈开的是同一辆车");
            }

            //车库没有白色的车，就new一辆白色的车
            Driver d3 = new Driver("大头儿子");
            Car c3 = carFactory.GetCar("白色");
            c3.Use(d3);
            Console.ReadKey();
        }
    }

    ///抽象车类
    public abstract class Car
    {
        //开车
        public abstract void Use(Driver d);
    }

    /// <summary>
    /// 具体的车类
    /// </summary>
    public class RealCar : Car
    {
        //颜色
        public string Color { get; set; }
        public RealCar(string color)
        {
            this.Color = color;
        }
        //开车
        public override void Use(Driver d)
        {
            Console.WriteLine($"{d.Name}开{this.Color}的车");
        }
    }

    /// <summary>
    /// 车库
    /// </summary>
    public class CarFactory
    {
        private Dictionary<string, Car> carPool = new Dictionary<string, Car>();
        //初始的时候，只有红色和绿色两辆汽车
        public CarFactory()
        {
            carPool.Add("红色", new RealCar("红色"));
            carPool.Add("绿色", new RealCar("蓝色"));
        }
        //获取汽车
        public Car GetCar(string key)
        {
            //如果车库有就用车库里的车，车库没有就买一个（new一个）
            if (!carPool.ContainsKey(key))
            {
                carPool.Add(key, new RealCar(key));
            }
            return carPool[key];
        }
    }

    /// <summary>
    /// 司机类
    /// </summary>
    public class Driver
    {
        public string Name { get; set; }
        public Driver(string name)
        {
            this.Name = name;
        }
    }


}
