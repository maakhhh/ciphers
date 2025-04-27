using CSharpFunctionalExtensions;

namespace Ciphers;

public interface IEncoder<T>
{
    Result<EncodeResult<T>> Encode(string text, T key);
    Result<EncodeResult<T>> Decode(string text, T key);
    Result<EncodeResult<T>> Hack(string text);
}