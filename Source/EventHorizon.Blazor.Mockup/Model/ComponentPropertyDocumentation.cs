namespace EventHorizon.Blazor.Mockup
{
    public class ComponentPropertyDocumentation
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Default { get; set; } = DefaultTypes.NULL_TYPE;
        public string Property { get; set; } = DefaultTypes.NULL_TYPE;

        public PropertyDescription Metadata { get; set; } = new PropertyDescription();
    }
}
