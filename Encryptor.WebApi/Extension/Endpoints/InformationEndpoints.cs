using Encryptor.Application.AggregateWebApi.Features.Information.AmountUsageCiphers;
using Encryptor.Application.AggregateWebApi.Features.Information.AmountUsageMessages;
using Encryptor.Application.AggregateWebApi.Features.Information.GetFullInfo;
using Encryptor.Application.AggregateWebApi.Features.Information.GetMethodUsageInfo;
using Encryptor.Application.AggregateWebApi.Features.Information.InformationOfAllMessages;
using Microsoft.AspNetCore.Mvc;

namespace Encryptor.WebApi.Extension.Endpoints;

public static class InformationEndpoints
{
    public static RouteGroupBuilder AddInformationEndpoints(this RouteGroupBuilder route)
    {
        route.MapGet("/", ([FromServices]GetFullInfoHandler handler) => handler.Handle());
        route.MapGet("/{name}", 
            ([FromQuery] string name, GetMethodUsageInfoHandler handler) 
            => handler.Handle(name));
        route.MapGet("usage-ciphers", (AmountOfUsageCiphersHandler handler) => handler.Handle());
        route.MapGet("all-messages", (InformationOfAllMessagesHandler handler) => handler.Handle());
        route.MapGet("usage-messages", (AmountOfUsageMessagesHandler handler) => handler.Handle());
        return route;
    }
}