using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Portfolio.Shared
{
    public class Technology
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}
