using System.Text;

namespace Ciphers.WordProcessing;

public class FiveSymbolsProcessor : IResultWordProcessor
{
    public string Process(string text)
    {
        var result = new StringBuilder();

        for (var i = 0; i < text.Length; i++)
        {
            result.Append(text[i]);
            
            if ((i + 1) % 5 == 0 && i != text.Length - 1)
                result.Append(' ');
        }
        
        return result.ToString();
    }
}