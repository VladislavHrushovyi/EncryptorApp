using Encryptor.Application.AggregateWebApi.Features.Encrypt;
using Encryptor.WebApi.Extension.DbProviders;
using Encryptor.WebApi.Extension.Endpoints;
using Encryptor.WebApi.Extension.ServiceHandler;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MigrationDatabase();
app.UseHttpsRedirection();

app.MapGroup("")
    .AddEncryptionEndpoints()
    .WithTags("Encryption endpoints");

app.MapGroup("information")
    .AddInformationEndpoints()
    .WithTags("Information endpoints");

app.Run();