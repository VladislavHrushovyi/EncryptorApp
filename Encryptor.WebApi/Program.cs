using Encryptor.Application.AggregateWebApi.Features.Encrypt;
using Encryptor.WebApi.Extension.ServiceHandler;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/encryption", (EncryptRequest req, [FromServices] EncryptService service) 
    => service.ExecuteEncryption(req));

app.Run();