using Sirius.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.Services.SessionServices
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppLogger<SessionService> _logger;

        public SessionService(IHttpContextAccessor httpContextAccessor, IAppLogger<SessionService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public void AddInt(string key, int value)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32(key, value);
        }

        public void AddString(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        public string GetString(string key)
        {
            try
            {
                return _httpContextAccessor.HttpContext.Session.GetString(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return null;
            }
        }
        public int? GetInt(string key)
        {
            try
            {
                return _httpContextAccessor.HttpContext.Session.GetInt32(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return null;
            }
        }
        public void AddObject<T>(string key, T data)
           where T : class
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key, data);
        }

        public T GetObject<T>(string key)
            where T : class
        {
            try
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<T>(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return null;
            }
        }

    }
}
