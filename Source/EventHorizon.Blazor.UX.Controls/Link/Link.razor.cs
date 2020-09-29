namespace EventHorizon.Blazor.UX.Controls.Link
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public class LinkModel
        : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public string @class { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }
    }
}
