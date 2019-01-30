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
    public class ProductService : DatabaseEntityService<Product>, IProductService
    {
        public ProductService(IAppLogger<ProductService> logger, IMainRepository<Product> productRepository)
            : base(productRepository, logger)
        {
        }
    }
}
