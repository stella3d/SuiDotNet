using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class ExecutionStatus
    {
        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; }
        
        [JsonProperty("error")]
        public string? Error { get; }

        public ExecutionStatus(string status, string? error = null)
        {
            Status = status;
            Error = error;
        }

        public override string ToString()
        {
            return Error != null ? $"{{ status: {Status}, error: {Error} }}" : $"{{ status: {Status} }}";
        }
    }
}