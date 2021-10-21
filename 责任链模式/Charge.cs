using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链模式
{
    public class Charge : AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"This is {this.GetType().Name} {this.Name} Audit");
            if (context.Hour <= 16)
            {
                context.AuditResult = true;
                context.AuditRemark = "允许请假！";
            }
            else
            {
                base.AuditNext(context);
            }
        }
    }
}
