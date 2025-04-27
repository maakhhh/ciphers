using System.Collections;
using System.Text;
using Ciphers.Ciphers;
using Ciphers.WordProcessing;
using CSharpFunctionalExtensions;

namespace Ciphers;

public class Encoder : IEncoder<string>
{
    private readonly ICipher<string> cipher;
    private readonly IEnumerable<IWordProcessor> wordProcessors;
    private readonly IEnumerable<IResultWordProcessor> resultProcessors;

    public Encoder(ICipher<string> cipher,
        IEnumerable<IWordProcessor> wordProcessors,
        IEnumerable<IResultWordProcessor> resultProcessors)
    {
        this.cipher = cipher;
        this.wordProcessors = wordProcessors;
        this.resultProcessors = resultProcessors;
    }
    
    public Result<EncodeResult<string>> Encode(string text, string key)
    {
        return ExceptionHandler<EncodeResult<string>>.Execute(() =>
        {
            text = ApplyProcessors(text);
            key = ApplyProcessors(key);
            if (string.IsNullOrEmpty(text))
                return Result.Failure<EncodeResult<string>>($"Текст не может быть пустым");
            if (string.IsNullOrEmpty(key))
                return Result.Failure<EncodeResult<string>>("Ключ не может быть пустым");

            var result = ApplyResultProcessors(cipher.Encrypt(text, key).Value);

            return new EncodeResult<string>
            {
                ReceivedText = text,
                ResultText = result,
                Key = key
            };
        });
    }

    public Result<EncodeResult<string>> Decode(string text, string key)
    {
        return ExceptionHandler<EncodeResult<string>>.Execute(() =>
        {
            text = ApplyProcessors(text);
            key = ApplyProcessors(key);
            if (string.IsNullOrEmpty(text))
                return Result.Failure<EncodeResult<string>>($"Текст не может быть пустым");
            if (string.IsNullOrEmpty(key))
                return Result.Failure<EncodeResult<string>>("Ключ не может быть пустым");

            return new EncodeResult<string>
            {
                ReceivedText = text,
                ResultText = cipher.Decrypt(text, key).Value,
                Key = key
            };
        });
    }

    public Result<EncodeResult<string>> Hack(string text)
    {
        return ExceptionHandler<EncodeResult<string>>.Execute(() =>
        {
            text = ApplyProcessors(text);
            if (string.IsNullOrEmpty(text))
                return Result.Failure<EncodeResult<string>>("Текст не может быть пустым");
            var result = cipher.Hack(text);
            if (result.IsFailure)
                return result.ConvertFailure<EncodeResult<string>>();
            return new EncodeResult<string>
            {
                ReceivedText = text,
                ResultText = ApplyResultProcessors(result.Value.HackedText),
                Key = result.Value.Key
            };
        });
    }

    private string ApplyProcessors(string text)
    {
        return wordProcessors.Aggregate(
            text,
            (current, processor) => processor.Process(current));
    }

    private string ApplyResultProcessors(string text)
    {
        return resultProcessors.Aggregate(
            text,
            (current, processor) => processor.Process(current));
    }
}