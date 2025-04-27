using System.Text.RegularExpressions;

namespace Ciphers.WordProcessing
{
    public class RussianLettersOnlyProcessor : IWordProcessor
    {
        private static readonly Regex RussianLettersRegex = new("[^а-яёА-ЯЁ]", RegexOptions.Compiled);
        
        public string Process(string input) => RussianLettersRegex.Replace(input, string.Empty);
    }
}