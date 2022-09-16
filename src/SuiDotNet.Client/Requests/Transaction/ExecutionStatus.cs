using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class ExecutionStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}