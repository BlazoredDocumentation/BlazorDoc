using System;

namespace BlazorDoc.Components
{
    public class TypeColorMapper
    {
        IColorTheme _colorTheme;
        public TypeColorMapper(IColorTheme colorTheme)
        {
            _colorTheme = colorTheme;
        }
        public string GetColorByType(Type type)
        {
            if (type == null)
                return "";

            if (type.IsPrimitive)
                return _colorTheme.Primitive;
            else if (type.IsEnum)
                return _colorTheme.Enum;
            else if (type.IsClass)
                return _colorTheme.Class;
            else if (type.IsInterface)
                return _colorTheme.Interface;
            else
                return _colorTheme.Class;
        }
    }
}
