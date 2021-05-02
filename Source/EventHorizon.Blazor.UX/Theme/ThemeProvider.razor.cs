namespace EventHorizon.Blazor.UX.Theme
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public class ThemeProviderModel
        : ComponentBase
    {
        [Inject]
        public IJSRuntime Runtime { get; set; } = null!;

        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;

        [Parameter]
        public IDictionary<string, string> Theme { get; set; } = new Dictionary<string, string>
        {
            //{"--main-foreground-color", "white" }
        };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Runtime.InvokeVoidAsync(
                    "ehzBlazorUx.updateTheme",
                    Theme
                );
            }
        }
    }
}
