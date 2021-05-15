using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlazorDoc.Core
{
    public class ReadmePageReader : IReadmePageReader
    {
        Assembly _assembly;
        public ReadmePageReader(Assembly assembly) => _assembly = assembly;

        public string SearchText { get; set; }
        private bool HasSearchtext() => !string.IsNullOrWhiteSpace(SearchText);
        public IEnumerable<IReadmePage> GetAllReadMePages()
        {
            List<ReadmePage> examplePages = new();

            foreach (Type readmeComponent in GetReadmeComponents())
            {
                examplePages.Add(new ReadmePage(readmeComponent));
            }

            return examplePages.OrderBy(page => page.Displayname);
        }

        private List<Type> GetReadmeComponents()
        {
            return _assembly.ExportedTypes.Where(t => t.IsSubclassOf(typeof(ComponentBase))
                                      && t.Name.Contains("ReadMe")
                                      || t.Name.Contains("Readme"))
                                        .ToList()
                                        .FilterByRouteAttrib();
        }

        public IEnumerable<IReadmePage> GetLatestReadmePages()
        {
            return GetAllReadMePages().OrderByDescending(page => page.CreatedAt).Take(5);
        }
        public IEnumerable<IReadmePage> GetReadmePages()
        {
            if (HasSearchtext())
                return GetAllReadMePages().Where(ex => ex.Displayname.ToUpper().Contains(SearchText.ToUpper()));
            else
                return GetAllReadMePages();
        }
        public IReadmePage GetReadmePage(Type type)
        {
            return GetAllReadMePages().Where(p => p.FullName == type.FullName || p.Displayname == type.Name).FirstOrDefault();
        }

    }
}
