using Microsoft.OpenApi.Models;

namespace Jobs.Core.Config
{
    public static class DocumentationConfig
    {
        public static void RegisterDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Jobs API",
                    Description = "API de um portal de vagas para empregos",
                    Contact = new OpenApiContact
                    {
                        Name = "Treinaweb",
                        Url = new Uri("https://youtu.be/J7mJRp8OG2U"),
                        Email = "contato@hotmail.com"
                    }
                });
            });
        }
    }
}
