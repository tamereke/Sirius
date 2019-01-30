using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.Models
{
    public class OperationResult
    {
        public OperationResult()
        {

        }
        public virtual void SetError(string message)
        {
            Message = message;
        }

        public virtual OperationResult SetError(Exception ex)
        {
            Message = ex.GetaAllMessages();
            return this;
        }

        public string Message
        { get; set; }

        public bool Ok
        {
            get
            {
                return string.IsNullOrEmpty(Message);
            }
        }
    }

    public class OperationResult<T>
    {
        public OperationResult()
        {

        }
        public OperationResult(T entity)
        {
            Item = entity;
        }

        public OperationResult<T> SetError(string message)
        {
            Message = message;
            return this;
        }

        public string Message
        { get; set; }

        public bool Ok
        {
            get
            {
                return string.IsNullOrEmpty(Message);
            }
        }

        public OperationResult<T> SetError(Exception ex)
        {
            Message = ex.GetaAllMessages();
            return this;
        }
         
        public T Item
        {
            get; set;
        }

    }
}
