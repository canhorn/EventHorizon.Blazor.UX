namespace EventHorizon.Blazor.Mockup
{
    using Microsoft.AspNetCore.Components;

    public static class StringExtensions
    {
        public static RenderFragment ToRenderFragment(
            this string val)
        {
            return new RenderFragment((builder) => builder.AddMarkupContent(0, val));
        }
    }
}
