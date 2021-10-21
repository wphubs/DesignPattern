using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链模式
{
    public class AuditorBuilder
    {
        /// <summary>
        /// 那就反射+配置文件
        /// 链子的组成都可以通过配置文件
        /// </summary>
        /// <returns></returns>
        public static AbstractAuditor Build()
        {
            AbstractAuditor pm = new PM()
            {
                Name = "张琪琪"
            };
            AbstractAuditor charge = new Charge()
            {
                Name = "吴可可"
            };
            //AbstractAuditor ceo = new CEO()
            //{
            //    Name = "加菲猫"
            //};

            pm.SetNext(pm);
            charge.SetNext(charge);
            //ceo.SetNext(ceo);
            return pm;
        }
    }
}
