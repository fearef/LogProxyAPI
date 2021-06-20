using System;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

namespace LogProxyAPI.Models
{
    public class LogMessageBase
    {

        public static JsonSerializerOptions JsonSerializerOptions { get; private set; } = new JsonSerializerOptions() { PropertyNamingPolicy = new LogMessageJsonNamingPolicy() };

        public DateTime ReceivedAt { get; set; }

        public string Id { get; set; }

        public string Summary { get; set; }

        public string Message { get; set; }

        public class LogMessageJsonNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name)
            {
                switch (name)
                {
                    case "Summary": return name;
                    case "Message": return name;                    
                }
                return  char.ToLowerInvariant(name[0]) + name.Substring(1);
            }
        }
       
    }
}
