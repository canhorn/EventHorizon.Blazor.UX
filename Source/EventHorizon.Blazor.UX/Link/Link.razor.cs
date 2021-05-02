namespace EventHorizon.Blazor.UX.Link
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public class LinkModel
        : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; } = null!;

        [Parameter]
        public string @class { get; set; } = null!;
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; } = null!;
    }
}
