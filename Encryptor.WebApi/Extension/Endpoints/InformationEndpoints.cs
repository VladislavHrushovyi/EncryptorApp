using Encryptor.Application.AggregateWebApi.Features.Information.GetFullInfo;
using Microsoft.AspNetCore.Mvc;

namespace Encryptor.WebApi.Extension.Endpoints;

public static class InformationEndpoints
{
    public static RouteGroupBuilder AddInformationEndpoints(this RouteGroupBuilder route)
    {
        route.MapGet("/", ([FromServices]GetFullInfoHandler handler) => handler.Handle());
        route.MapGet("/{name}", ([FromQuery] string name) => name);
        return route;
    }
}