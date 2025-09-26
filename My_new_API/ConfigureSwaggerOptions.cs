using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace My_new_API
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {

        private readonly IApiVersionDescriptionProvider _versionProvider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider versionProvider)
        {
            _versionProvider = versionProvider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _versionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, createAPIVersion(description));
            }
        }
        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public OpenApiInfo createAPIVersion(ApiVersionDescription description)
        {
            return new OpenApiInfo()
            {
                Title = "My_new_API_Version",
                Version = description.ApiVersion.ToString()
            };
        }
    }
}
