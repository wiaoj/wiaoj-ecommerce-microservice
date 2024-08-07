using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Wiaoj.Libraries.AspNetCore;
public static class HttpJsonOptionsExtensions {
    public static IServiceCollection ConfigureCustomHttpJsonOptions(this IServiceCollection services) {
        return services.ConfigureCustomHttpJsonOptions(null);
    }

    public static IServiceCollection ConfigureCustomHttpJsonOptions(this IServiceCollection services, Action<JsonOptions>? jsonOptions) {
        return services.ConfigureHttpJsonOptions(options => {
            options.SerializerOptions.WriteIndented = true;
            options.SerializerOptions.IncludeFields = true;
            options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.SerializerOptions.MaxDepth = 0;
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.SerializerOptions.PropertyNameCaseInsensitive = true;
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());

            jsonOptions?.Invoke(options);
        });
    }
}