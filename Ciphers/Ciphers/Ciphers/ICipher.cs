using CSharpFunctionalExtensions;

namespace Ciphers.Ciphers;

public interface ICipher<TKey>
{
    Result<string> Encrypt(string source, TKey key);
    Result<string> Decrypt(string source, TKey key);
    Result<HackResult<TKey>> Hack(string source);
}