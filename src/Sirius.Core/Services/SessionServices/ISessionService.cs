using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.Services.SessionServices
{
    public interface ISessionService
    {
        void AddObject<T>(string key, T data) where T : class;
        T GetObject<T>(string key) where T : class;
        void AddInt(string key, int value);
        int? GetInt(string key);
        void AddString(string key, string value);
        string GetString(string key);
    }
}
