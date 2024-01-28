using Encryptor.Application.AggregateWebApi.Features.Encrypt;

namespace Encryptor.WebApi.Extension.Endpoints;

public static class Encryption
{
    public static RouteGroupBuilder AddEncryptionEndpoints(this RouteGroupBuilder route)
    {
        route.MapPost("/encryption", (EncryptRequest req, EncryptService service)
            => service.ExecuteEncryption(req));
        return route;
    }
}