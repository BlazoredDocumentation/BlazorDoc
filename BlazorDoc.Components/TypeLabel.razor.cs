using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorDoc.Components
{
    public class TypeLabelBase : TypeinfoCompoentBase
    {
        public string TypeDisplayname { get; set; } = "";
        [CascadingParameter] public Type CascadingType { get; set; }
        protected override void OnInitialized()
        {
            InitParameters();
            base.OnInitialized();
        }
        protected override void OnParametersSet()
        {
            InitParameters();
            base.OnParametersSet();
        }
        private void InitParameters()
        {
            Type = CascadingType ?? Type;

            if (HasType())
                TypeDisplayname = TypeDisplayNameConverter.GetDisplayname(Type);

        }
        public bool HasType() => Type != null;
    }
}
