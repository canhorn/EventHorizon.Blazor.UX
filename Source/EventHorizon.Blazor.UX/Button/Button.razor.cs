namespace EventHorizon.Blazor.UX.Button
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.JSInterop;

    public class ButtonModel
        : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string SoundPath { get; set; } = "/_content/EventHorizon.Blazor.UX/sounds/click.mp3";
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }

        public string Animation { get; set; } = string.Empty;

        public async Task HandleOnClick(
            MouseEventArgs args
        )
        {
            await OnClick.InvokeAsync(args);

            Animation = "--blink";
            if (!string.IsNullOrEmpty(SoundPath))
            {
                // TODO: Create Sound Service
                await JSRuntime.InvokeVoidAsync(
                    "ehzBlazorUx.playAudioFile",
                    SoundPath
                );
            }
            // TODO: Create Delay Service
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(10);
                Animation = string.Empty;
                InvokeAsync(StateHasChanged);
            });
        }
    }
}
