using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogProxyAPI.Models
{
    public class LogMessageProxy : LogMessageBase
    {
         [JsonPropertyName("Title")]
        public new string Summary { get; set; }

         [JsonPropertyName("Text")]
        public new string Message { get; set; }
    }
}
