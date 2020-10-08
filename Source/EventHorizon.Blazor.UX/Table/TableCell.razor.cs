namespace EventHorizon.Blazor.UX.Table
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class TableCellModel
        : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }
    }
}
