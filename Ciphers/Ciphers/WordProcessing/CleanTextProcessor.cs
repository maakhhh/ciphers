using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Ciphers.WordProcessing;

public class CleanTextProcessor : IWordProcessor
{
    public string Process(string input) =>
        Regex.Replace(input, @"[\p{P}\p{S}]+", "").Replace('Ё', 'Е').Replace('ё', 'е');
}