using System.Reflection;
using ChatApp.API.Constants;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

namespace ChatApp.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(name: SwaggerConfig.API_VERSION,
                    info: new OpenApiInfo()
                    {
                        Title = "Chat App API",
                        Version = SwaggerConfig.API_VERSION
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                // add authorization to Swagger
                options.AddSecurityDefinition(name: SwaggerConfig.BEARER_SCHEME,
                    securityScheme: new OpenApiSecurityScheme()
                    {
                        Description = SwaggerConfig.DESCRIPTION,
                        Name = SwaggerConfig.AUTHORIZATION,
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = SwaggerConfig.BEARER_SCHEME

                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = SwaggerConfig.BEARER_SCHEME
                            }
                        },
                    Array.Empty<string>()
                    }
                });
            });
        }
    }
} 