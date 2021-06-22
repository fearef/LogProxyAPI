using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogProxyAPI.Models
{
    public class LogMessageProxy : LogMessageAbstract
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }
       
        public static implicit operator LogMessageProxy(LogMessageExternal logMessageExternal)
        {
            return new LogMessageProxy()
            {
                Id = logMessageExternal.Id,
                Title = logMessageExternal.Summary,
                Text = logMessageExternal.Message,
                ReceivedAt = logMessageExternal.ReceivedAt
            };
        } 
    }
}
