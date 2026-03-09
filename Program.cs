using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Kakeibo_Front.Components;
using Kakeibo_Front.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = builder.Configuration["KakeiboApi:BaseUrl"] ?? "http://localhost:7071/api/";
var functionKey = builder.Configuration["KakeiboApi:FunctionKey"];

builder.Services.AddHttpClient<KakeiboApiService>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
})
.AddHttpMessageHandler(() => new FunctionKeyHandler(functionKey));

await builder.Build().RunAsync();
