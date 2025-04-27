using System.Text;
using CSharpFunctionalExtensions;

namespace Ciphers.Ciphers;

public class VigenereCipher : ICipher<string>
{
    private List<char> alphabet = ['А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П',
        'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'];
    
    public Result<string> Encrypt(string source, string key) => Process(source, key, true);

    public Result<string> Decrypt(string source, string key) => Process(source, key, false);
    
    public Result<HackResult<string>> Hack(string source)
    {
        var keyLength = FindKeyLengthTapeMethod(source);
        var groups = GroupTextByKeyLength(source, keyLength);
        var key = CalculateKey(groups);

        return new HackResult<string>
        {
            ReceivedText = source,
            HackedText = Decrypt(source, key).Value,
            Key = key
        };
    }

    private Result<string> Process(string source, string key, bool encrypt)
    {
        var result = new StringBuilder(source.Length);
        for (var i = 0; i < source.Length; i++)
        {
            var sourceChar = source[i];
            var keyChar = key[i % key.Length];
            
            var textPos = alphabet.IndexOf(sourceChar);
            var keyPos = alphabet.IndexOf(keyChar);

            var newPos = encrypt
                ? (textPos + keyPos) % alphabet.Count
                : (textPos - keyPos + alphabet.Count) % alphabet.Count;
            
            result.Append(alphabet[newPos]);
        }
        
        return Result.Of(result.ToString());
    }

    private int FindKeyLengthTapeMethod(string source)
    {
        var maxLength = source.Length < 20 ? source.Length - 1 : 20;
        var lengths = new List<(int, double)>();
        var rates = new List<double>();

        for (var l = 1; l < maxLength; l++)
        {
            var rate = CalculateRate(source, l);
            lengths.Add((l, rate));
        }
        return CalculateKeyLength(FindOutliersZScore(lengths, 1.7));
    }
    
    public static List<int> FindOutliersZScore(List<(int, double)> data, double threshold = 2.0)
    {
    
        var mean = data.Average(l => l.Item2);
        var stdDev = Math.Sqrt(data.Select(x => Math.Pow(x.Item2 - mean, 2)).Average());
    
        if (stdDev == 0)
            return new List<int>();
    
        return data.Where(x => Math.Abs((x.Item2 - mean) / stdDev) > threshold).Select(l => l.Item1).ToList();
    }

    private int CalculateKeyLength(List<int> lengths)
    {
        if (lengths.Count == 0)
            return 1;
        var minLength = int.MaxValue;
        var maxDivideCount = 0;

        foreach (var length in lengths)
        {
            var count = lengths.Count(l => l % length == 0);
            if (count > maxDivideCount && length < minLength)
            {
                maxDivideCount = count;
                minLength = length;
            }
        }
        
        return minLength;
    }

    private double CalculateRate(string source, int length)
    {
        var count = 0;
        var allCount = 0;

        for (var i = 0; i < source.Length - length; i++)
        {
            if (source[i] == source[i + length])
                count++;
            allCount++;
        }

        return count > 0 ? count / (double)allCount : 0;
    }

    private List<string> GroupTextByKeyLength(string source, int keyLength)
    {
        var groups = new List<string>();

        for (var i = 0; i < keyLength; i++)
        {
            var group = new StringBuilder();
            for (var j = i; j < source.Length; j += keyLength)
                group.Append(source[j]);
            groups.Add(group.ToString());
        }
        
        return groups;
    }

    private string CalculateKey(List<string> groups)
    {
        var key = new StringBuilder();
        var caesar = new CaesarCipher();

        foreach (var group in groups)
        {
            var caesarKey = caesar.Hack(group).Value.Key;
            key.Append(alphabet[caesarKey]);
        }
        
        return key.ToString();
    }
}