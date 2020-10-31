using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Commands.Infrastructure
{
    public class CommandResponse
    {
        public CommandResponse() { }

        public CommandResponse(string message, bool status = true, bool tokenStatus = true)
        {
            TokenStatus = tokenStatus;
            Status = status;
            Message = message;
        }

        public CommandResponse(string message, object obj, bool status = true, bool tokenStatus = true)
        {
            TokenStatus = tokenStatus;
            Status = status;
            Message = message;
            Object = obj;
        }
        public CommandResponse(string message, object obj, int count, bool status = true, bool tokenStatus = true)
        {
            TokenStatus = tokenStatus;
            Status = status;
            Message = message;
            Object = obj;
            Count = count;
        }
        public CommandResponse(string message, object obj, int count, Guid uid, bool status = true, bool tokenStatus = true)
        {
            TokenStatus = tokenStatus;
            Status = status;
            Message = message;
            Object = obj;
            Count = count;
            UId = uid;
        }

        public CommandResponse(string message, object obj, Guid uid, bool status = true, bool tokenStatus = true)
        {
            TokenStatus = tokenStatus;
            Status = status;
            Message = message;
            Object = obj;
            UId = uid;
        }

        public bool TokenStatus { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
        public int Count { get; set; }
        public Guid UId { get; set; }
    }
}
