namespace EventHorizon.Blazor.UX.Controls.Table
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class TableRowModel
        : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }
    }
}
