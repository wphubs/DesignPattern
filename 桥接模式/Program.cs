using System;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            UserBLL bll1 = new CustomerUserBLL();
            bll1.SetDAL(new UserMSSQLDAL());
            bll1.Add();

            Console.ReadKey();
            Console.WriteLine();

            UserBLL bll2 = new CustomerUserBLL();
            bll2.SetDAL(new UserMySQLDAL());
            bll2.Add();

            Console.ReadKey();
        }
    }

    #region 抽象
    //Abstracttion
    public abstract class UserBLL
    {
        private UserDAL dal;

        public void SetDAL(UserDAL userDAL)
        {
            dal = userDAL;
        }

        public virtual void Add()
        {
            dal.AddUser();
        }
    }
    //Implementor interface
    public abstract class UserDAL
    {
        public abstract void AddUser();
    }
    #endregion

    //BLL 实现 RefinedAbstracttion
    public class CustomerUserBLL : UserBLL
    {
        public override void Add()
        {
            Console.WriteLine("Customer-User-BLL Add");
            base.Add();
        }
    }

    //MySQL DAL ConcreteImplementorA
    public class UserMySQLDAL : UserDAL
    {
        public override void AddUser()
        {
            Console.WriteLine("--User-My-SQL-DAL AddUser");
        }
    }

    //MSSQL DAL 实现 ConcreteImplementorB
    public class UserMSSQLDAL : UserDAL
    {
        public override void AddUser()
        {
            Console.WriteLine("--User-MS-SQL-DAL AddUser");
        }
    }
}
