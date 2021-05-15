using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BlazorDoc.Core
{
    public interface IReadmePageReader
    {
        /// <summary>
        /// Searchtext for Searching in Readme Pages
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// List of all Pages that contains Readme, ReadMe or Overview in filename
        /// </summary>
        /// <returns></returns>
        IEnumerable<IReadmePage> GetReadmePages();
        IReadmePage GetReadmePage(Type pageType);
        IEnumerable<IReadmePage> GetLatestReadmePages();
    }
}