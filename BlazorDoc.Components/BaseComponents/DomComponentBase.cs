using Microsoft.AspNetCore.Components;

namespace BlazorDoc.Components
{
    public abstract class DomComponentBase : ComponentBase
    {
        [Parameter] public virtual bool Visible { get; set; } = true;
        [Parameter] public virtual string Class { get; set; }
        [Parameter] public virtual string Style { get; set; }
    }
}
