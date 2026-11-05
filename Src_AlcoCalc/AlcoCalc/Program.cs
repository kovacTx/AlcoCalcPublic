using AlcoCalc.Services;
using AlcoCalc.Values;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace AlcoCalc;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddMudServices();

        builder.Services.AddSingleton<CalculatorValues>();
        builder.Services.AddSingleton<Calculator1A_1>();
        builder.Services.AddSingleton<Calculator1A_2>();
        builder.Services.AddSingleton<Calculator1A_3>();
        builder.Services.AddSingleton<Calculator1A_4>();
        builder.Services.AddSingleton<Calculator1A_5>();
        builder.Services.AddSingleton<Calculator1A_6>();
        builder.Services.AddSingleton<Calculator1A_7>();
        builder.Services.AddSingleton<Calculator1A_8>();

        builder.Services.AddSingleton<Calculator1B_1>();
        builder.Services.AddSingleton<Calculator1B_2>();

        builder.Services.AddSingleton<Calculator2_1>();
        builder.Services.AddSingleton<Calculator2_2>();
        builder.Services.AddSingleton<Calculator2_3>();
        builder.Services.AddSingleton<Calculator2_4>();

        builder.Services.AddSingleton<Returner>();

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }
}