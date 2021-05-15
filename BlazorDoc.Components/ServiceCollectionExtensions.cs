using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace BlazorDoc.Components
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorDoc(this IServiceCollection serviceCollection, string pathToDocumentationFile)
        {
            return serviceCollection.AddScoped<IXmlDocumentationReader>(x => new XmlDocumentationReader(pathToDocumentationFile))
                                    .AddScoped<ITypeDisplayNameConverter, TypeDisplayNameConverter>();
        }
        public static IServiceCollection AddBlazorDoc(this IServiceCollection serviceCollection, List<Assembly> assemblies)
        {

            return serviceCollection.AddTransient<IXmlDocumentationReader>(x => new XmlDocumentationReader(assemblies))
                                    .AddTransient<ITypeDisplayNameConverter, TypeDisplayNameConverter>()
                                    .AddSingleton<IColorTheme, VisualStudioDarkColorTheme>();
        }
        public static IServiceCollection AddBlazorDoc(this IServiceCollection serviceCollection, IXmlDocumentationReader xmlDocumentationReader)
        {
            return serviceCollection.AddScoped(x => xmlDocumentationReader)
                                    .AddScoped<ITypeDisplayNameConverter, TypeDisplayNameConverter>();
        }
    }
}
