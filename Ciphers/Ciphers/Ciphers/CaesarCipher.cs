using CSharpFunctionalExtensions;

namespace Ciphers.Ciphers;

public class CaesarCipher : ICipher<int>
{
    private List<char> alphabet = ['А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П',
        'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'];
    
    private Dictionary<char, double> characterFrequency = new()
    {
        {'О', 0.090}, {'Е', 0.072}, {'Ё', 0.072}, {'А', 0.062}, {'И', 0.062}, {'Т', 0.053}, {'Н', 0.053}, 
        {'С', 0.045}, {'Р', 0.040}, {'В', 0.038}, {'Л', 0.035}, {'К', 0.028}, {'М', 0.026}, {'Д', 0.025}, {'П', 0.023}, 
        {'У', 0.021}, {'Я', 0.040}, {'Ы', 0.016}, {'З', 0.016}, {'Ъ', 0.014}, {'Ь', 0.014}, {'Б', 0.014}, {'Г', 0.013},
        {'Ч', 0.012}, {'Й', 0.010}, {'Х', 0.018}, {'Ж', 0.007}, {'Ю', 0.006}, {'Ш', 0.006}, {'Ц', 0.003}, {'Щ', 0.003},
        {'Э', 0.003}, {'Ф', 0.002}
    };
    
    public Result<string> Encrypt(string source, int key) => Result.Of(Process(source, key));

    public Result<string> Decrypt(string source, int key) => Result.Of(Process(source, -key));

    public Result<HackResult<int>> Hack(string source)
    {
        var key = 0;
        var minError = double.MaxValue;
        

        for (var shift = 0; shift < alphabet.Count; shift++)
        {
            var decrypted = Decrypt(source, shift).Value;
            var frequency = GetCharacterFrequency(decrypted);
            var error = CalculateFrequencyError(frequency);

            if (error < minError)
            {
                minError = error;
                key = shift;
            }
        }
        
        return new HackResult<int>
        {
            ReceivedText = source,
            HackedText = Decrypt(source, key).Value,
            Key = key
        };
    }

    private string Process(string input, int shift)
    {
        shift %= alphabet.Count;
        var result = new char[input.Length];
    
        for (var i = 0; i < input.Length; i++)
        {
            var index = (alphabet.IndexOf(input[i]) + shift) % alphabet.Count;
            index = index < 0 ? index + alphabet.Count : index;
            result[i] = alphabet[index];
        }
    
        return new string(result);
    }

    private Dictionary<char, double> GetCharacterFrequency(string source)
    {
        var result = new Dictionary<char, double>();
        foreach (var c in source)
            if (result.ContainsKey(c))
                result[c] += 1;
            else
                result.Add(c, 1);
        
        foreach (var c in result.Keys)
            result[c] /= source.Length;
        
        return result;
    }

    private double CalculateFrequencyError(Dictionary<char, double> frequency)
    {
        var error = 0d;

        foreach (var c in frequency.Keys)
            error += (characterFrequency[c] - frequency[c]) * (characterFrequency[c] - frequency[c]);
        
        return error;
    }
}