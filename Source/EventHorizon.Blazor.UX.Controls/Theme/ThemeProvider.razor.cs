namespace EventHorizon.Blazor.UX.Controls.Theme
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public class ThemeProviderModel
        : ComponentBase
    {
        [Inject]
        public IJSRuntime Runtime { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public IDictionary<string, string> Theme { get; set; } = new Dictionary<string, string>();

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
