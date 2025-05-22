using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioControl;

public class ApiResponse
{
    public string Resp { get; set; } = "";
    public int? Level { get; set; }
    public bool? Muted { get; set; }
    public string? Message { get; set; }
}