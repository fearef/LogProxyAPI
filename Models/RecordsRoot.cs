using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogProxyAPI.Models
{
    public class RecordsRoot
    {
        public IEnumerable<Record> Records { get; set; }

        [JsonIgnore]
        public string Offset { get; set; }
    }

    public class Record
    {
        [JsonIgnore]
        public string Id { get; set; }

        [JsonPropertyName("fields")]
        public LogMessageExternal LogMessage { get; set; }

        [JsonIgnore]
        public DateTime CreatedTime { get; set; }
    }
}
