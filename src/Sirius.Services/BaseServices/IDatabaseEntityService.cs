using Sirius.Core;
using Sirius.Core.Data;
using Sirius.Core.Entities;
using Sirius.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Services
{
    public interface IDatabaseEntityService<TEntity>
        where TEntity : IEntity
    {
        OperationResult<List<TEntity>> GetItems(Func<TEntity, bool> filter);
        OperationResult<TEntity> Insert(TEntity item);
        OperationResult<TEntity> Update(TEntity item);
        OperationResult<TEntity> Delete(TEntity item);
        OperationResult<TEntity> Delete(int id);
    }
}
