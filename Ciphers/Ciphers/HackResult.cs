namespace Ciphers;

public class HackResult<T>
{
    public string ReceivedText { get; set; }
    public string HackedText { get; set; }
    public T Key { get; set; }
}