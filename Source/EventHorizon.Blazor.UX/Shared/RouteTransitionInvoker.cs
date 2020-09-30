﻿using System.Threading.Tasks;
using BlazorTransitionableRoute;
using Microsoft.JSInterop;

namespace EventHorizon.Blazor.UX.Shared
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
            bool isBackwards
        )
        {
            await _jsRuntime.InvokeVoidAsync(
                "window.ehzBlazorUx.transitionFunction",
                isBackwards
            );
        }
    }

}
