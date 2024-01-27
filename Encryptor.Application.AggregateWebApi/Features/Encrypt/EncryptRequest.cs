namespace Encryptor.Application.AggregateWebApi.Features.Encrypt;

public class EncryptRequest
{
    public string CipherName { get; set; }
    public string Text { get; set; }
}