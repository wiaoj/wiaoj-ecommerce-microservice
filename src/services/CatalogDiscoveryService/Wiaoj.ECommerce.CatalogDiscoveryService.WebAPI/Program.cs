using Microsoft.AspNetCore.Server.Kestrel.Core;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((options) => {
    options.ConfigureEndpointDefaults(configure => {
        configure.Protocols = HttpProtocols.Http3;
        configure.UseHttps();
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

await app.RunAsync(default(CancellationToken));