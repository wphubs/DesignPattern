using System;
using System.Collections.Generic;
using System.Text;

namespace 模板方法模式
{
    /// <summary>
    /// 银行客户端
    /// </summary>
    public class ClientRegular : AbstractClient
    {
        /// <summary>
        /// 活期  定期  利率不同
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public override double CalculateInterest(double balance)
        {
            return balance * 0.003;
        }
    }
}
