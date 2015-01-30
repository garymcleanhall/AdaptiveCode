using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crud;
using System.Threading;

namespace ConsoleUIDecorators
{
    public class SaveAuditing<TEntity> : ISave<TEntity>
    {
        public SaveAuditing(ISave<TEntity> decorated, ISave<AuditInfo> auditSave)
        {
            this.decorated = decorated;
            this.auditSave = auditSave;
        }

        public void Save(TEntity entity)
        {
            decorated.Save(entity);
            var auditInfo = new AuditInfo
            {
                UserName = Thread.CurrentPrincipal.Identity.Name,
                TimeStamp = DateTime.Now
            };
            auditSave.Save(auditInfo);
        }

        private readonly ISave<TEntity> decorated;
        private readonly ISave<AuditInfo> auditSave;
    }
}
