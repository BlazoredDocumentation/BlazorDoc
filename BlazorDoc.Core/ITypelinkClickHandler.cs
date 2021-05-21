using System;

namespace BlazorDoc.Core
{
    public interface ITypelinkClickHandler
    {
        void OnTypelinkClicked(Type type);
    }
}
