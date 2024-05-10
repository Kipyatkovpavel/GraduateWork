using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraduateWork.Models
{    public record AuthResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; init; }

        [JsonPropertyName("date_format")]
        public string? DateFormat { get; init; }

        [JsonPropertyName("time_format")]
        public string? TimeFormat { get; init; }
    }
}
