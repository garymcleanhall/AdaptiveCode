using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crud;

namespace ConsoleUIDecorators
{
    public class DeleteConfirmation<TEntity> : IDelete<TEntity>
    {
        public DeleteConfirmation(IDelete<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }

        public void Delete(TEntity entity)
        {
            
            {
                decoratedCrud.Delete(entity);
            }
        }

        private readonly IDelete<TEntity> decoratedCrud;
    }
}
