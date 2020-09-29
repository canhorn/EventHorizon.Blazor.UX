namespace EventHorizon.Blazor.UX.Controls.Text
{
    using Microsoft.AspNetCore.Components;

    public class TextModel
        : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
