using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core
{
   public  static class ExceptionExtensions
    {
        private const string StrCoreErrorLineSeparator = "--------------------[Core Exception]--------------------";
        private const string StrWrapErrorLineSeparator = "--------------------[Wrap Exception]--------------------";
        private const string StrTab = "\t";
        public static string GetaAllMessages(this Exception ex)
        {

            var sb = new StringBuilder();

            do
            {
                if (ex.InnerException == null)
                {
                    sb.AppendLine(StrCoreErrorLineSeparator);
                    sb.AppendLine("Source\t\t: " + ex.Source.Trim());
                    sb.AppendLine("Method\t\t: " + ex.TargetSite.Name);
                    sb.AppendLine("Date\t\t: " + DateTime.Now.ToLongTimeString());
                    sb.AppendLine("Time\t\t: " + DateTime.Now.ToShortDateString());
                    sb.AppendLine("Error\t\t: " + ex.Message.Trim());
                    sb.AppendLine("Stack Trace\t: " + ex.StackTrace.Trim());
                }
                else
                {
                    sb.AppendLine(StrTab + StrWrapErrorLineSeparator);
                    sb.AppendLine(StrTab + "Source\t\t: " + ex.Source.Trim());
                    sb.AppendLine(StrTab + "Method\t\t: " + ex.TargetSite.Name);
                    sb.AppendLine(StrTab + "Date\t\t: " + DateTime.Now.ToLongTimeString());
                    sb.AppendLine(StrTab + "Time\t\t: " + DateTime.Now.ToShortDateString());
                    sb.AppendLine(StrTab + "Error\t\t: " + ex.Message.Trim());
                    sb.AppendLine(StrTab + "Stack Trace\t: " + ex.StackTrace.Trim());

                    ex = ex.InnerException;
                }
            } while (ex.InnerException != null);

            return sb.ToString();

            //string message = string.Empty;
            //Exception innerException = exp;

            //do
            //{
            //    message = message + (string.IsNullOrEmpty(innerException.Message) ? string.Empty : innerException.Message);
            //    innerException = innerException.InnerException;
            //}
            //while (innerException != null);

            //return message;

            //var stringBuilder = new StringBuilder();

            //while(exp != null)
            //{
            //    stringBuilder.AppendLine(exp.Message);
            //    stringBuilder.AppendLine(exp.StackTrace).AppendLine();

            //    exp = exp.InnerException;
            //}

            //return stringBuilder.ToString();
        }
    }
}
