using BlazorTransitionableRoute;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace EventHorizon.Blazor.UX.Shared.Layout
{
    public class RouteTransitionInvoker : IRouteTransitionInvoker
    {
        private readonly IJSRuntime _jsRuntime;

        public RouteTransitionInvoker(
            IJSRuntime jsRuntime
        )
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InvokeRouteTransitionAsync(
            bool backwards
        )
        {
            await _jsRuntime.InvokeVoidAsync(
                "window.ehzBlazorUx.transitionFunction",
                backwards
            );
        }

        public async Task InvokeRouteTransitionAsync(Transition transition)
        {
            await _jsRuntime.InvokeVoidAsync(
                "window.ehzBlazorUx.transitionFunction",
                transition.Backwards
            );
        }
    }

}
