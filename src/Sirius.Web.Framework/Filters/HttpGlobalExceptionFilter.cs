using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Sirius.Core;

namespace Sirius.Web.Framework.Filters
{

    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IAppLogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(IAppLogger<HttpGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        { 
            _logger.LogError(context.Exception);
        }
    }
}
