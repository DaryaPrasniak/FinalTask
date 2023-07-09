using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailFinalTask.Models
{
    public class Milestone
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; } = string.Empty;
        [JsonProperty("description")] public string Description { get; set; } = string.Empty;
        [JsonProperty("is_completed")] public bool IsCompleted { get; set; }
        [JsonProperty("project_id")] public int ProjectId { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(IsCompleted)}: " +
                $"{IsCompleted}, {nameof(ProjectId)}: {ProjectId}";
        }

        protected bool Equals(Milestone other)
        {
            return Name == other.Name && Description == other.Description &&
                   IsCompleted == other.IsCompleted && ProjectId == other.ProjectId;
        }

        public override bool Equals(object? obj)
        {
            return Equals((Milestone)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Description);
            hashCode.Add(IsCompleted);
            hashCode.Add(ProjectId);
            return hashCode.ToHashCode();
        }
    }
}
