using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application
{
    public class QueryResult<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
        public QueryResult(bool Success, T Result, string Message)
        {
            this.Success = Success;
            this.Result = Result;
            this.Message = Message;
        }
    }
}
