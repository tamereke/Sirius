using Sirius.Core;
using Sirius.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services
{
    public class BaseService
    {
        private readonly IAppLogger _logger;

        public BaseService(IAppLogger logger)
        { 
            _logger = logger;
        }

        public BaseService()
        {

        }

        public OperationResult Execute( Action<OperationResult> action)
        {
            OperationResult result = new OperationResult();
            try
            {
                action(result);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex);
                result.SetError(ex.ToString());
            }
            return result;
        }

        public OperationResult<T> Execute<T>( Action<OperationResult<T>> action)
        {
            OperationResult<T> result = new OperationResult<T>();
            try
            {
                action(result);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex);
                result.SetError(ex.ToString());
            }
            return result;
        }
    }
}
