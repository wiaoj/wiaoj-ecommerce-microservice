using Elastic.Clients.Elasticsearch.QueryDsl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Wiaoj.ECommerce.CatalogDiscoveryService.WebAPI.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((options) => {
    options.ConfigureEndpointDefaults(configure => {
        configure.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        configure.UseHttps();
    });
});

builder.Services.AddCors(setup => {
    setup.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped<ElasticsearchCatalogItemRepository>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();
app.UseHttpsRedirection();

app.MapGet("api/{page}/{size}", ([FromRoute] Int32 page, [FromRoute] Int32 size, ElasticsearchCatalogItemRepository a) => {
    return Results.Ok(a.SearchAsync(page, size));
});

await app.RunAsync(default(CancellationToken));