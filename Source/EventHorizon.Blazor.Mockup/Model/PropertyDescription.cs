namespace EventHorizon.Blazor.Mockup
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class PropertyDescription
    {
        public string PropertyName { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        [JsonIgnore]
        public Type Type { get; set; } = null!;
        public bool IsPrimitive { get; set; }
        public IEnumerable<PropertyAttribute> Attributes { get; set; } = new List<PropertyAttribute>();
        public IEnumerable<PropertyDescription> Properties { get; set; } = new List<PropertyDescription>();
    }
}
