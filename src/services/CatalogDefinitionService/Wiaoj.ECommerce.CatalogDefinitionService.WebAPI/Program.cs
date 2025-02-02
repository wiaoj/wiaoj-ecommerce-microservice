using Mediator;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Wiaoj.ECommerce.CatalogDefinitionService.Application;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.Categories.Commands.CreateCategory;
using Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence;
using Wiaoj.Libraries.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((options) => {
    options.ConfigureEndpointDefaults(configure => {
        configure.Protocols = HttpProtocols.Http3;
        configure.UseHttps();
    });
});

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddPersistenceServices()
    .AddCustomResponseCompression()
    .ConfigureCustomHttpJsonOptions()
    .AddCors(setup => {
        setup.AddDefaultPolicy(policy => {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();

app.UseHttpsRedirection();

app.MapPost("api/categories",
    async (CreateCategoryCommandRequest request,
           ISender sender,
           CancellationToken cancellationToken) => {
               CreateCategoryCommandResponse response = await sender.Send(request, cancellationToken);
               return Results.Ok(response.Id);
           });

app.MapPost("api/catalog-items",
    async (CreateCatalogItemCommandRequest request,
           ISender sender,
           CancellationToken cancellationToken) => {
               CreateCatalogItemCommandResponse response = await sender.Send(request, cancellationToken);
               return Results.Ok(response.Id);
           });

await app.RunAsync(default(CancellationToken));