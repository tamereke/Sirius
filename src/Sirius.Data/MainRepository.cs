using Sirius.Core.Cache;
using Sirius.Core.Data;
using Sirius.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Data
{
    /// <summary>
    /// Represents the Entity Framework repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class MainRepository<TEntity> : RepositoryBase<TEntity>,IMainRepository<TEntity>
        where TEntity : BaseEntity
    {
        #region Ctor

        public MainRepository(MainContext context,ICacheService cacheService)
            :base(context,cacheService)
        {
            
        }

        #endregion
    }
}
