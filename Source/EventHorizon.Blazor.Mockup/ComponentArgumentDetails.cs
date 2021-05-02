using System.Diagnostics.CodeAnalysis;

namespace EventHorizon.Blazor.Mockup
{
    public class ComponentArgumentDetails
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [MaybeNull]
        public object DefaultValue { get; set; }
        [MaybeNull]
        public object PropertyValue { get; set; }
    }
}
