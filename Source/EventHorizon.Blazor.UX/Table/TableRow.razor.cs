namespace EventHorizon.Blazor.UX.Table
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class TableRowModel
        : ComponentBase
    {
        [Parameter]
        public bool EnableHighlight { get; set; } = true;
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; } = null!;
    }
}
