using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogProxyAPI.Models
{
    public abstract class LogMessageAbstract
    {
        public DateTime ReceivedAt { get; set; }

        public string Id { get; set; }

        public static JsonSerializerOptions JsonSerializerOptions { get; private set; } = new JsonSerializerOptions() { PropertyNamingPolicy = new LogMessageJsonNamingPolicy() };
        public class LogMessageJsonNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name)
            {
                switch (name)
                {
                    case "Summary": return name;
                    case "Message": return name;
                }
                return char.ToLowerInvariant(name[0]) + name.Substring(1);
            }
        }


    }
}
