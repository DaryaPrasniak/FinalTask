using AngleSharp.Dom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestRailFinalTask.Models
{
    public class Section
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; } = string.Empty;
        [JsonProperty("description")] public string Description { get; set; } = string.Empty;
        [JsonProperty("depth")] public int Depth { get; set; }
        [JsonProperty("display_order")] public int DisplayOrder { get; set; }
        [JsonProperty("parent_id")] public int ParentId { get; set; }
        [JsonProperty("suite_id")] public int SuiteId { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(Depth)}: " +
                $"{Depth}, {nameof(DisplayOrder)}: {DisplayOrder}, {nameof(ParentId)}: {ParentId}, {nameof(SuiteId)}: " +
                $"{SuiteId}";
        }

        protected bool Equals(Section other)
        {
            return Name == other.Name && Description == other.Description &&
                   Depth == other.Depth && DisplayOrder == other.DisplayOrder &&
                   ParentId == other.ParentId && SuiteId == other.SuiteId;
        }

        public override bool Equals(object? obj)
        {
            return Equals((Section)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Description);
            hashCode.Add(Depth);
            hashCode.Add(DisplayOrder);
            hashCode.Add(ParentId);
            hashCode.Add(SuiteId);
            return hashCode.ToHashCode();
        }
    }
}
