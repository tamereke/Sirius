using Sirius.Core;
using Sirius.Core.Data;
using Sirius.Core.Models;
using Sirius.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Services.BusinessService
{
    public class CategoryService : DatabaseEntityService<Category>, ICategoryService
    {
        public CategoryService(IAppLogger<CategoryService> logger, IMainRepository<Category> repository)
            : base(repository, logger)
        {
        }

        public override OperationResult<Category> Delete(Category item)
        {
            return base.Delete(item);
        }
    }
}
