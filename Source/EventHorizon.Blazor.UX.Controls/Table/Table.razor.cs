namespace EventHorizon.Blazor.UX.Controls.Table
{
    using Microsoft.AspNetCore.Components;

    public class TableModel
        : ComponentBase
    {
        [Parameter]
        public RenderFragment Head { get; set; }
        [Parameter]
        public RenderFragment Body { get; set; }
    }
}
