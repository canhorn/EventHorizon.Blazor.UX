namespace EventHorizon.Blazor.UX.Button
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;

    public class ButtonModel
        : ComponentBase
    {
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }

        public string Animation { get; set; } = string.Empty;

        public async Task HandleOnClick(
            MouseEventArgs args
        )
        {
            await OnClick.InvokeAsync(args);

            Animation = "--blink";
            // TODO: Create Delay Service
            await Task.Delay(10);
            Animation = string.Empty;
        }
    }
}
