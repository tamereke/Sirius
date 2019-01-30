using Sirius.Core.AppConfig;
using Sirius.Core.Logger;
using Microsoft.Extensions.Logging;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core
{
    //TODO : write message to console
    //TODO : add other logger method    
    public class NLogLogger<T> : BaseLogger<T>
    {
        private NLog.Logger _logger = null;

        public NLogLogger()
        {
            
            _logger = NLog.LogManager.GetLogger(typeof(T).Name);
        }

        public override bool Enabled
        {
            get
            {
                return SiriusCore.Instance.AppConfig.Loging.CustomSettings.Enabled;
            }
        }

        public override void LogDebug(string message)
        {
            if (!Enabled)
                return;
            System.Diagnostics.Debug.WriteLine(message);
            _logger.Debug(message);
        }

        public override void LogWarn(string message)
        {
            if (!Enabled)
                return;
            _logger.Warn(message);
        }

        public override void LogError(Exception exception)
        {
            if (!Enabled)
                return;
            _logger.Error(exception.GetaAllMessages());
        }

        public override void LogFatal(Exception exception)
        {
            _logger.Fatal(exception.GetaAllMessages());
        }

        public override void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public override void LogTrace(string message)
        {
            _logger.Trace(message);
        }
        /// <summary>
        /// LogLevel= Info
        /// </summary>
        /// <param name="message"></param>
        public override void Log(string message)
        {
            _logger.Info(message);
        }

        public override void Dispose()
        {
            //NLog.LogManager.Shutdown();
        } 

        //public void Debug(Exception exception)
        //{

        //}

        //public void Debug(string format, params object[] args)
        //{

        //}

        //public void Debug(Exception exception, string format, params object[] args)
        //{

        //}

        //public void Error(string format, params object[] args)
        //{
        //    _logger.Log(LogLevel.Error, format,args);
        //}

        //public void Error(Exception exception, string format, params object[] args)
        //{
        //    _logger.Log(LogLevel.Error, exception, format, args);
        //}

        //public void Fatal(string format, params object[] args)
        //{
        //    _logger.Log(LogLevel.Error, format, args);
        //}

        //public void Fatal(Exception exception, string format, params object[] args)
        //{
        //    _logger.Log(LogLevel.Error, exception, format, args);
        //}


        //public void Info(string format, params object[] args)
        //{

        //}

        //public void Info(Exception exception, string format, params object[] args)
        //{

        //}

        //public void Trace(string format, params object[] args)
        //{

        //}

        //public void Trace(Exception exception, string format, params object[] args)
        //{

        //}

        //public void Warn(Exception exception)
        //{

        //}

        //public void Warn(string format, params object[] args)
        //{

        //}

        //public void Warn(Exception exception, string format, params object[] args)
        //{

        //}
    }
}
