namespace EventHorizon.Blazor.UX.Animate
{
    using Microsoft.AspNetCore.Components;

    public class AnimateModel
        : ComponentBase
    {
        [Parameter]
        public bool AnimateEnabled { get; set; } = true;
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
