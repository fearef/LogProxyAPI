using System;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

namespace LogProxyAPI.Models
{
    public class LogMessageExternal : LogMessageAbstract
    {       
        public string Summary { get; set; }

        public string Message { get; set; }

        public static implicit operator LogMessageExternal(LogMessageProxy logMessageProxy)
        {
            return new LogMessageExternal()
            {
                Id = logMessageProxy.Id,
                Summary = logMessageProxy.Title,
                Message = logMessageProxy.Text,
                ReceivedAt = logMessageProxy.ReceivedAt
            };
        }

    }
}
