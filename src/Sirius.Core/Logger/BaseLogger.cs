using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.Logger
{
    public abstract class BaseLogger<T> : IAppLogger<T>
    {
        public abstract bool Enabled {get;}

        public abstract void Dispose();
        public abstract void Log(string message); 
        public abstract void LogDebug(string message); 
        public abstract void LogError(Exception exception);
        public abstract void LogFatal(Exception exception);
        public abstract void LogInfo(string message);
        public abstract void LogTrace(string message);
        public abstract void LogWarn(string message);
    }
}
