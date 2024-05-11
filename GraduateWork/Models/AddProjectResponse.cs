using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraduateWork.Models
{
    public record AddProjectResponse
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("note")] public string Note { get; set; }

        [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }

        [JsonPropertyName("access")] public List<object>? Access { get; set; } 

        [JsonPropertyName("avatar_id")] public int? AvatarId { get; set; }

        [JsonPropertyName("avatar_index")] public int? AvatarIndex { get; set; }

        [JsonPropertyName("default_access")] public int DefaultAccess { get; set; }

        [JsonPropertyName("default_role_id")] public int? DefaultRoleId { get; set; }
    }
}
