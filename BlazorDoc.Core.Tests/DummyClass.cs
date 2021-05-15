using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDoc.Core.Tests
{
    /// <summary>
    /// SummaryOfDummyClass
    /// </summary>
    class DummyClass
    {
        /// <summary>
        /// SummaryOfMyStringProp
        /// </summary>
        public string MyStringProp { get; set; }
        
        /// <summary>
        /// SummaryOfMyIntProp
        /// </summary>
        public int MyIntProp { get; set; }

        /// <summary>
        /// SummaryOfMyBoolProp
        /// </summary>
        public bool MyBoolProp { get; set; }

        /// <summary>
        /// SummaryOfMyTypeProp
        /// </summary>
        public Type MyTypeProp { get; set; }

        /// <summary>
        /// SummaryOfMyListOfString
        /// </summary>
        public List<string> MyListOfString { get; set; }

    }
}
