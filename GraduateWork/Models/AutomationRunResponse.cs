using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraduateWork.Models
{
    public record AutomationRunResponse
    {
        [JsonPropertyName("id")] public int Id { get; set; }
    }
}
