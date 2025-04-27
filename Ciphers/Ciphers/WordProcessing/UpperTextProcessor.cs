namespace Ciphers.WordProcessing;

public class UpperTextProcessor : IWordProcessor
{
    public string Process(string input) => input.ToUpper();
}