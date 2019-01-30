using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core
{
    public interface IAppLogger: IDisposable
    {
        bool Enabled { get; }


        void LogDebug(string message);
        void LogError(Exception exception);
        void LogFatal(Exception exception);
        void LogInfo(string message);
        void LogWarn(string message);
        void LogTrace(string message);

        void Log(string message);

        //IAppLogger<TLoggerCategory> GetLogger<TLoggerCategory>();


        //void Debug(Exception exception);
        //void Debug(string format, params object[] args);
        //void Debug(Exception exception, string format, params object[] args);
        //void Error(Exception exception);
        //void Error(string format, params object[] args);
        //void Error(Exception exception, string format, params object[] args);

        //void Fatal(string format, params object[] args);
        //void Fatal(Exception exception, string format, params object[] args);
        //void Info(Exception exception);
        //void Info(string format, params object[] args);
        //void Info(Exception exception, string format, params object[] args);
        //void Trace(Exception exception);
        //void Trace(string format, params object[] args);
        //void Trace(Exception exception, string format, params object[] args);
        //void Warn(Exception exception);
        //void Warn(string format, params object[] args);
        //void Warn(Exception exception, string format, params object[] args);
    }
}
