using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AudioControl
{
    public class CommandResponse
    {
        [JsonPropertyName("resp")]
        public string Resp { get; set; } = string.Empty;

        // Optional depending on Resp
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        
        [JsonPropertyName("level")]
        public int? Level { get; set; }

        [JsonPropertyName("muted")]
        public bool? Muted { get; set; }
    }
}
