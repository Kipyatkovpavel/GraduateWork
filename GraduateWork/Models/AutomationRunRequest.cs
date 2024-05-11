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

        [JsonPropertyName("tags")] public List<string> Tags { get; set; }

        [JsonPropertyName("artifacts")] public List<Artifact> Artifacts { get; set; }

        [JsonPropertyName("fields")] public List<Field>? Fields { get; set; }

        [JsonPropertyName("links")] public List<Link>? Links { get; set; }
    }

    public class Artifact
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; }

        [JsonPropertyName("mime_type")] public string MimeType { get; set; }

        [JsonPropertyName("size")] public long Size { get; set; }
    }

    public class Field
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("type")] public int Type { get; set; }

        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; }
    }
}
