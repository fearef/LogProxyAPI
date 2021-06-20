using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogProxyAPI.Utils
{
    public class IdHandler
    {
        public static string GetNextId()
        {
            // Check whether the environment variable exists.
            string currentId = Environment.GetEnvironmentVariable("LogProxyAPI_MessageId");
            // If necessary, create it.
            if (currentId == null)
            {
                Environment.SetEnvironmentVariable("LogProxyAPI_MessageId", "0");
                return "0";
            }
            else
            {
                int.TryParse(currentId, out int nextId);
                Environment.SetEnvironmentVariable("LogProxyAPI_MessageId", $"{++nextId}");
                return $"{nextId}";
            }

        }
    }
}
