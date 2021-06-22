using LogProxyAPI.Models;
using LogProxyAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogProxyAPI.Controllers
{

    [ApiController]
    [Route("api/messages")]
    [Route("api")]
    [Route("")]
    public class LogMessageController : ControllerBase
    {
        private HttpClient _clientAirTableAPI;
        private readonly ILogger<LogMessageController> _logger;

        public LogMessageController(ILogger<LogMessageController> logger)
        {
            _logger = logger;
            _clientAirTableAPI = new HttpClient();
            _clientAirTableAPI.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "key46INqjpp7lMzjd");
        }

        [HttpGet]
        public async Task<IEnumerable<LogMessageProxy>> GetLogMessagesAsync()
        {
            var response = await _clientAirTableAPI.GetAsync("https://api.airtable.com/v0/appD1b1YjWoXkUJwR/Messages?maxRecords=3&view=Grid%20view");
            var jstring = response.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;
            var jobject = JsonSerializer.Deserialize<RecordsRoot>(jstring, LogMessageAbstract.JsonSerializerOptions);
            return jobject?.Records?
                .Select(x => (LogMessageProxy)x.LogMessage);         
        }

        [HttpPost]
        public async Task<IActionResult> PostLogMessageAsync([FromBody] LogMessageProxy logMessageProxy)
        {
            try
            {
                logMessageProxy.Id = IdHandler.GetNextId();
                logMessageProxy.ReceivedAt = DateTime.Now;
                var record = new RecordsRoot()
                {
                    Records = new Record[1] { new Record() { LogMessage = logMessageProxy } }
                };

                HttpContent content = new StringContent(JsonSerializer.Serialize(record, LogMessageExternal.JsonSerializerOptions), Encoding.UTF8, "application/json");
                var response = await _clientAirTableAPI.PostAsync("https://api.airtable.com/v0/appD1b1YjWoXkUJwR/Messages", content);

                return Ok(response.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (HttpRequestException)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            catch (Exception)
            {
                return StatusCode(Response.StatusCode);
            }           
        }


    }
}
