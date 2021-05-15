using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDoc.Components
{
    public partial class TypeIcon : TypeinfoCompoentBase
    {
        [Parameter] public string IconKey { get; set; }
        [Parameter] public string FontSize { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await Task.CompletedTask;
            if (Type != null)
                IconKey = GetKeyByType();
        }

        string GetKeyByType()
        {
            if (Type.IsPrimitive) return CodIconKey.PrimitiveSquare;
            if (Type.IsClass && !Type.IsValueType) return CodIconKey.Class;
            if (Type.IsInterface) return CodIconKey.Interface;
            if (Type.IsEnum) return CodIconKey.Enum;
            return "";
        }


    }
}
