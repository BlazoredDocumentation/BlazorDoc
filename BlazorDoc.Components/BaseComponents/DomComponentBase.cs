using Microsoft.AspNetCore.Components;

namespace BlazorDoc.Components
{
    public abstract class DomComponentBase : ComponentBase
    {
        /// <summary>
        /// Hides the Component if value is false
        /// </summary>
        [Parameter] public virtual bool Visible { get; set; } = true;

        /// <summary>
        /// Optional Css Classes
        /// </summary>
        [Parameter] public virtual string Class { get; set; }
        /// <summary>
        /// Optional Styles
        /// </summary>
        [Parameter] public virtual string Style { get; set; }
    }
}
