using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraduateWork.Models
{
    public record AutomationRunRequest
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("source")] public string Source { get; set; }
    }

}
