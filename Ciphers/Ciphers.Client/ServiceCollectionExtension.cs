using Ciphers.Ciphers;
using Ciphers.WordProcessing;
using Microsoft.Extensions.DependencyInjection;

namespace Ciphers.Client;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddForms(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<MainForm>();
        
        return serviceCollection;
    }

    public static IServiceCollection AddLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IEncoder<string>, Encoder>()
            .AddSingleton<ICipher<string>, VigenereCipher>();
            
        return serviceCollection;
    }

    public static IServiceCollection AddWordProcessors(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IWordProcessor, CleanTextProcessor>()
            .AddSingleton<IWordProcessor, UpperTextProcessor>()
            .AddSingleton<IWordProcessor, RussianLettersOnlyProcessor>();

        serviceCollection.AddSingleton<IResultWordProcessor, FiveSymbolsProcessor>();
        
        return serviceCollection;
    }
}