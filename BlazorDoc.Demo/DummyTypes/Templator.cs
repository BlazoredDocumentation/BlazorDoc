namespace BlazorDoc.Demo.DummyTypes
{
    /// <summary>
    /// Das ist ein DummyTemplator
    /// </summary>
    /// <typeparam name="T">T muss eine Klasse sein</typeparam>
    public class Templator<T> where T : class
    {
        public string Identification { get; set; }
    }

}
