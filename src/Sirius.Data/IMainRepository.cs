using Sirius.Core.Entities;
using System.Collections.Generic;
using System.Linq;
namespace Sirius.Core.Data
{
    /// <summary>
    /// Represents an entity repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial interface IMainRepository<TEntity> :  IRepository<TEntity>
        where TEntity : IEntity
    {
    }
}

