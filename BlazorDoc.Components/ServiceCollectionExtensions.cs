using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace BlazorDoc.Components
{
    public static class ServiceCollectionExtensions
    {
        private static IServiceCollection AddBlazorDoc(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITypeDisplayNameConverter, TypeDisplayNameConverter>()
                             .AddSingleton<IColorTheme, VisualStudioDarkColorTheme>()
                             .AddSingleton<ITypelinkClickHandler,DefaultNavigationManagerTypelinkClickHandler>();

            return serviceCollection;
        }
        public static IServiceCollection AddBlazorDoc(this IServiceCollection serviceCollection, string pathToDocumentationFile)
        {

            return serviceCollection.AddBlazorDoc()
                                    .AddScoped<IXmlDocumentationReader>(x => new XmlDocumentationReader(pathToDocumentationFile));
        }
        public static IServiceCollection AddBlazorDoc(this IServiceCollection serviceCollection, List<Assembly> assemblies)
        {

            return serviceCollection.AddBlazorDoc()
                                    .AddTransient<IXmlDocumentationReader>(x => new XmlDocumentationReader(assemblies));
        }
        public static IServiceCollection AddBlazorDoc(this IServiceCollection serviceCollection, IXmlDocumentationReader xmlDocumentationReader)
        {
            return serviceCollection.AddBlazorDoc()
                                    .AddScoped(x => xmlDocumentationReader);
        }
    }
}
