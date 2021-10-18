using System;

namespace 工厂模式
{
    class Program
    {

        //动机
        //在软件系统中，经常面临“某个对象”的创建工作；由于需求的变化，这个对象经常面临着剧烈的变化，但是它却拥有比较稳定的接口。
        //“封装机制”来隔离出“这个易变对象”的变化，从而保持系统中“其他依赖对象的对象”不随着需求变化而变化
        //意图
        //定义一个用于创建对象的接口，让子类决定实例化哪一个类。Factory Method使得一个类的实例化延迟到子类




        static IFactory fac = new MySQLFactory();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ISqlHelper sqlHelper = fac.CreateSqlHelper();
            sqlHelper.Execute();
            Console.ReadKey();
        }



        #region 定义接口
        //约定工厂能创建那个类型产品 武器工厂
        public interface IFactory
        {
            ISqlHelper CreateSqlHelper();
        }
        //约定工厂产品的特点 武器
        public interface ISqlHelper
        {
            int Execute();
            object ExecuteScale();
        }
        #endregion

        #region 具体实现
        //工厂方法的具体实现 太刀工厂
        public class MSSQLFactory : IFactory
        {
            public ISqlHelper CreateSqlHelper()
            {
                return new MSSQLSqlHelper();
            }
        }

        //工厂方法的具体实现2 匕首工厂
        public class MySQLFactory : IFactory
        {
            public ISqlHelper CreateSqlHelper()
            {
                return new MySQLSqlHelper();
            }
        }



        //产品的具体实现 匕首
        public class MySQLSqlHelper : ISqlHelper
        {

            public int Execute()
            {
                Console.WriteLine("MySQLExecute");
                return 1;
            }

            public object ExecuteScale()
            {
                Console.WriteLine("MySQLExecuteScale");
                return new object();
            }
        }

        //产品的具体实现2 太刀
        public class MSSQLSqlHelper : ISqlHelper
        {

            public int Execute()
            {
                Console.WriteLine("MSSQLExecute");
                return 1;
            }

            public object ExecuteScale()
            {
                Console.WriteLine("MSSQLExecuteScale");
                return new object();
            }
        }
        #endregion
    }
}
