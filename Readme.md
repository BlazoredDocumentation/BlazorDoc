# BlazorDoc

[![Release-BlazorDoc.Components](https://github.com/BlazoredDocumentation/BlazorDoc/actions/workflows/Release.BlazorDoc.Components.yml/badge.svg)](https://github.com/BlazoredDocumentation/BlazorDoc/actions/workflows/Release.BlazorDoc.Components.yml)

[![Release-BlazorDoc.Core](https://github.com/BlazoredDocumentation/BlazorDoc/actions/workflows/Release.BlazorDoc.Core.yml/badge.svg)](https://github.com/BlazoredDocumentation/BlazorDoc/actions/workflows/Release.BlazorDoc.Core.yml)


![](https://badgen.net/github/release/BlazoredDocumentation/BlazorDoc/latest)


 
## QuickStart 

### Setup
```csharp
        public static List<Assembly> AssembliesToDoc = new List<Assembly>()
            {
                Assembly.GetAssembly(typeof(App)),
                  Assembly.GetAssembly(typeof(Components.Layouting.FlexPanel)),

            };
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IReadmePageReader>(x => new ReadmePageReader(Assembly.GetExecutingAssembly()));
            builder.Services.AddBlazorDoc(AssembliesToDoc);
            builder.Services.AddScoped<IAssemblyRegistrationContainer>(x => new AssemblyRegistrationContainer(AssembliesToDoc));
            await builder.Build().RunAsync();
        }
```

---
