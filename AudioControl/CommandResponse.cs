using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioControl
{
    public class CommandResponse
    {
        public string Resp { get; set; } = string.Empty;

        // Optional depending on Resp
        public string? Message { get; set; }
        public int? Level { get; set; }
        public bool? Muted { get; set; }
    }
}
