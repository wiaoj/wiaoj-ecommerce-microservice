using Microsoft.AspNetCore.RateLimiting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.ReverseProxy.json", false, true);
builder.Configuration.AddJsonFile("appsettings.Serilog.json", false, true);

builder.Services.AddOutputCache(options => {
    options.AddPolicy("20secPolicy", builder => {
        builder.Expire(TimeSpan.FromSeconds(20)).Cache();
    });
});

builder.Services.AddRateLimiter(rateLimiterOptions => {
    rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options => {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

WebApplication app = builder.Build();

app.UseOutputCache();
app.UseRateLimiter();
app.MapReverseProxy().CacheOutput("20secPolicy");

await app.RunAsync(default(CancellationToken));