using BlazorStrap;
using BlazorDoc.Components;
using BlazorDoc.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BlazorDoc.Demo.Shared;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.Xml.XPath;

namespace BlazorDoc.Demo
{
    public class Program
    {
        public static List<Assembly> AssembliesToDoc = new List<Assembly>()
            {
                Assembly.GetAssembly(typeof(App)),
                Assembly.GetAssembly(typeof(BlazorDoc.Demo.DummyTypes.Address)),
                Assembly.GetAssembly(typeof(BlazorDoc.Components.XmlDocumentationReader))
            };
        public static async Task Main(string[] args)
        {
 
             
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

            var stream= await httpClient.GetStreamAsync("BlazorDoc.Demo.xml");

            builder.Services.AddScoped(sp => httpClient)
                            .AddBlazorDoc(new XPathDocument(stream))
                            .AddSingleton<IReadmePageReader>(x => new ReadmePageReader(Assembly.GetExecutingAssembly()))
                            .AddSingleton<IAssemblyRegistrationContainer>(x=>new AssemblyRegistrationContainer(AssembliesToDoc))
                            .AddBootstrapCss();

            await builder.Build().RunAsync();
        }
    }
}
