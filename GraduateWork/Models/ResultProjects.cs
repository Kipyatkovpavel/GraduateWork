using GraduateWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraduateWork.Models
{
    public record ResultProjects
    {
        [JsonPropertyName("page")] public int Page { get; set; }
        [JsonPropertyName("prev_page")] public int? PrevPage { get; set; }
        [JsonPropertyName("next_page")] public int? NextPage { get; set; }
        [JsonPropertyName("last_page")] public int LastPage { get; set; }
        [JsonPropertyName("per_page")] public int PerPage { get; set; }
        [JsonPropertyName("total")] public int Total { get; set; }
        [JsonPropertyName("result")] public Projects[] Result { get; set; }
    }
}
