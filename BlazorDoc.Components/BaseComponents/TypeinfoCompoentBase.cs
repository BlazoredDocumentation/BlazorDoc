using Microsoft.AspNetCore.Components;
using System;


namespace BlazorDoc.Components
{
    public abstract class TypeinfoCompoentBase : DomComponentBase
    {

        private TypeColorMapper _typeColorMapper;

        [Parameter] public Type Type { get; set; }
        [Inject] public IColorTheme ColorTheme { get; set; }
        [Inject] public ITypeDisplayNameConverter TypeDisplayNameConverter { get; set; }
        public string TypeColor => _typeColorMapper.GetColorByType(Type);
        protected override void OnInitialized()
        {
            _typeColorMapper = new TypeColorMapper(ColorTheme);
        }
        protected override void OnParametersSet()
        {
            _typeColorMapper = new TypeColorMapper(ColorTheme);
        }
    }
}

