using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EventHorizon.Blazor.UX.Shared.Layout;
using EventHorizon.Blazor.UX.Shared.Data;

namespace EventHorizon.Blazor.UX.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<BlazorTransitionableRoute.IRouteTransitionInvoker, RouteTransitionInvoker>();

            builder.Services.AddSingleton<WeatherForecastService>();

            await builder.Build().RunAsync();
        }
    }
}
