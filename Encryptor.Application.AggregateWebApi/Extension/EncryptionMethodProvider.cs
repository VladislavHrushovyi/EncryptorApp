using Encryptor.Application.Features.Encryption.EncryptionMethods;
using Microsoft.Extensions.DependencyInjection;

namespace Encryptor.Application.AggregateWebApi.Extension;

public delegate IEncryptor EncryptionMethodResolver(string key);

public static class EncryptionMethodProvider
{
    public static void AddEncryptionMethods(this IServiceCollection services)
    {
        services.AddTransient<CaesarMethod>();
        services.AddTransient<XorEncryption>();
        services.AddScoped<VigenereEncryption>();

        services.AddTransient<EncryptionMethodResolver>(serviceProvider => key =>
            {
                return (key switch
                {
                    "Caesar" => serviceProvider.GetService<CaesarMethod>(),
                    "Xor" => serviceProvider.GetService<XorEncryption>(),
                    "Vigenere" => serviceProvider.GetService<VigenereEncryption>(),
                    _ => throw new KeyNotFoundException(message: $"{key} not found")
                })!;
            }
        );
    }
}