﻿using System;
using System.Collections.Generic;
using System.Text;

namespace 模板方法模式
{
    public abstract class AbstractClient
    {
        public void Query(int id, string name, string password)
        {
            if (this.CheckUser(id, password))
            {
                double balance = this.QueryBalance(id);
                double interest = this.CalculateInterest(balance);
                this.Show(name, balance, interest);
            }
            else
            {
                Console.WriteLine("账户密码错误");
            }
        }

        public bool CheckUser(int id, string password)
        {
            return DateTime.Now < DateTime.Now.AddDays(1);
        }

        public double QueryBalance(int id)
        {
            return new Random().Next(10000, 1000000);
        }

        /// <summary>
        /// 活期  定期  利率不同
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public abstract double CalculateInterest(double balance);

        public virtual void Show(string name, double balance, double interest)
        {
            Console.WriteLine("尊敬的{0}客户，你的账户余额为：{1}，利息为{2}",
                name, balance, interest);
        }
    }
}
