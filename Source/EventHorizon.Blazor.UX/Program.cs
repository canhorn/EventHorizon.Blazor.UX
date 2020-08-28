using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EventHorizon.Blazor.UX.Shared;

namespace EventHorizon.Blazor.UX
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<BlazorTransitionableRoute.NavigationState>();
            builder.Services.AddScoped<BlazorTransitionableRoute.NavigationStateHandler>();
            builder.Services.AddScoped<BlazorTransitionableRoute.IRouteTransitionInvoker, RouteTransitionInvoker>();

            await builder.Build().RunAsync();
        }
    }
}
