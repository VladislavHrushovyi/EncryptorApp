using Encryptor.Application.AggregateWebApi.Features.Encrypt.MethodAggregators;
using Encryptor.Application.Features.Encryption.EncryptionMethods;
using Microsoft.Extensions.DependencyInjection;

namespace Encryptor.Application.AggregateWebApi.Extension;

public delegate IEncryptor EncryptionMethodResolver(string key);

public static class EncryptionMethodProvider
{
    public static void AddEncryptionMethods(this IServiceCollection services)
    {
        services.AddScoped<CaesarEncryptionAggregator>();
        services.AddScoped<XorEncryptionAggregator>();
        services.AddScoped<VigenereEncryptionAggregator>();

        services.AddScoped<EncryptionMethodResolver>(serviceProvider => key =>
            {
                return (key switch
                {
                    "Caesar" => serviceProvider.GetService<CaesarEncryptionAggregator>()?.Cipher,
                    "Xor" => serviceProvider.GetService<XorEncryptionAggregator>()?.Cipher,
                    "Vigenere" => serviceProvider.GetService<VigenereEncryptionAggregator>()?.Cipher,
                    _ => throw new KeyNotFoundException(message: $"{key} not found")
                })!;
            }
        );
    }
}