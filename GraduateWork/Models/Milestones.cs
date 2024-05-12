using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraduateWork.Models
{
    public record Milestones
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("project_id")] public int ProjectId { get; set; }

        [JsonPropertyName("root_id")] public int? RootId { get; set; }

        [JsonPropertyName("parent_id")] public int? ParentId { get; set; }

        [JsonPropertyName("type_id")] public int TypeId { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("note")] public string Note { get; set; }

        [JsonPropertyName("is_started")] public bool IsStarted { get; set; }

        [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }

        [JsonPropertyName("start_date")] public DateTime? StartDate { get; set; }

        [JsonPropertyName("due_date")] public DateTime? DueDate { get; set; }

        [JsonPropertyName("automation_tags")] public List<string>? AutomationTags { get; set; }

        [JsonPropertyName("issues")] public List<object>? Issues { get; set; } 

        [JsonPropertyName("links")] public List<object>? Links { get; set; } 

        [JsonPropertyName("started_at")] public DateTime? StartedAt { get; set; }

        [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

        [JsonPropertyName("created_by")] public int CreatedBy { get; set; }

        [JsonPropertyName("updated_at")] public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("updated_by")] public int? UpdatedBy { get; set; }

        [JsonPropertyName("completed_at")] public DateTime? CompletedAt { get; set; }

        public record ResultContainer
        {
            [JsonPropertyName("result")]
            public Milestones Result { get; set; }

        }
    }
}
