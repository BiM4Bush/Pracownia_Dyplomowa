using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application
{
    public class CommandResult<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
        public CommandResult(bool Success, T Result, string Message)
        {
            this.Success = Success;
            this.Message = Message;
            this.Result = Result;
        }
    }
}
