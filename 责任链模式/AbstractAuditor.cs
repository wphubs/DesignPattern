using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链模式
{
    public abstract class AbstractAuditor
    {
        public string Name { get; set; }
        public abstract void Audit(ApplyContext context);

        private AbstractAuditor _NextAuditor = null;
        public void SetNext(AbstractAuditor auditor)
        {
            this._NextAuditor = auditor;
        }
        protected void AuditNext(ApplyContext context)
        {
            if (this._NextAuditor != null)
            {
                this._NextAuditor.Audit(context);
            }
            else
            {
                context.AuditResult = false;
                context.AuditRemark = "不允许请假！";
            }
        }
    }
}
