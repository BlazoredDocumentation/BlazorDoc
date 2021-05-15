namespace BlazorDoc.Components
{
    public interface IColorTheme
    {
        string Class { get; }
        string Enum { get; }
        string Interface { get; }
        string Primitive { get; }
        string Keyword { get; }
        string Parameter { get; }
        string MethodName { get; }
        string BackgorundColor { get; }
        string FontColor { get; }
    }
}
