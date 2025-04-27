namespace Ciphers;

public class EncodeResult<T>
{
    public string ReceivedText { get; set; }
    public string ResultText { get; set; }
    public T Key { get; set; }
}