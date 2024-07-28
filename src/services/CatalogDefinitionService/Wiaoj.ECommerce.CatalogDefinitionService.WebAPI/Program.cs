using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
using Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddPersistenceServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("api/catalog-items",
    async (CreateCatalogItemCommandRequest request,
           ISender sender,
           CancellationToken cancellationToken) => {
               CreateCatalogItemCommandResponse response = await sender.Send(request, cancellationToken);
               return Results.Ok(response.Id);
           });

await app.RunAsync(default(CancellationToken));
