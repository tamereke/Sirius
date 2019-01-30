using Sirius.Core;
using Sirius.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services
{
    //TODO : Create DatabaseEntityService 
    public class BaseService
    {
        /// <summary>
        /// Executes the 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public OperationResult Execute(IAppLogger logger, Action<OperationResult> action)
        {
            OperationResult result = new OperationResult();
            try
            {
                action(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                result.SetError(ex);
            }
            return result;
        }

        public OperationResult<T> Execute<T>(IAppLogger logger, Action<OperationResult<T>> action)
        {
            OperationResult<T> result = new OperationResult<T>();
            try
            {
                action(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                result.SetError(ex);
            }
            return result;
        }
    }
}
