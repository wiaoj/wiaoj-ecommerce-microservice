using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace Wiaoj.Libraries.AspNetCore;
public static class ResponseCompressionExtensions {
    public static IServiceCollection AddCustomResponseCompression(this IServiceCollection services) {
        return services.AddResponseCompression(options => {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
        }).Configure<BrotliCompressionProviderOptions>(options => {
            options.Level = CompressionLevel.Fastest;
        }).Configure<GzipCompressionProviderOptions>(options => {
            options.Level = CompressionLevel.SmallestSize;
        });
    }
}
