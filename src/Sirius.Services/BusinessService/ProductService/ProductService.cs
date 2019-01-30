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
    public class ProductService:BaseService,IProductService
    {
        private readonly IAppLogger<ProductService> _logger;
        private readonly IMainRepository<Product> _productRepository;

        public ProductService(IAppLogger<ProductService> logger
            ,IMainRepository<Product> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public OperationResult<List<Product>> GetItems()
        {
            return Execute<List<Product>>(_logger, result =>
            {
                result.Item = _productRepository.Table.ToList();
            });
        }

        public OperationResult<Product> Insert(Product item)
        {
            return Execute<Product>(_logger, result =>
            {
                _productRepository.Insert(item);
                result.Item = item;
            });
        }

        public OperationResult<Product> Update(Product item)
        {
            return Execute<Product>(_logger, result =>
            {
                _productRepository.Update(item);
                result.Item = item;
            });
        }

        public OperationResult<Product> Delete(Product item)
        {
            return Execute<Product>(_logger, result =>
            {
                _productRepository.Delete(item);
                result.Item = item;
            });
        }


    }
}
