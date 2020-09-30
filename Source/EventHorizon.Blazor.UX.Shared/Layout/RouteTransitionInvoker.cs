using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTransitionableRoute;
using Microsoft.JSInterop;

namespace EventHorizon.Blazor.UX.Shared.Layout
{
    public class RouteTransitionInvoker : IRouteTransitionInvoker
    {
        private readonly IJSRuntime _jsRuntime;

        public RouteTransitionInvoker(
            IJSRuntime jsRuntime
        )
        {
            this._jsRuntime = jsRuntime;
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
    }

}
