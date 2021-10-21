using System;

namespace 责任链模式
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApplyContext context = new ApplyContext()
            {
                Id = 506,
                Name = "小新",
                Hour = 32,
                Description = "我周一要请假回家",
                AuditResult = false,
                AuditRemark = ""
            };

            AbstractAuditor auditor = AuditorBuilder.Build();
            auditor.Audit(context);
            if (!context.AuditResult)
            {
                Console.WriteLine("不干了！");
            }
        }


    }
}
