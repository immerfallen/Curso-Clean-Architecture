using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchMvc.WebAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    // definir as configuracaoes
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme ="Bearer",
                    BearerFormat ="JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Header using bearer scheme. Example -----  Bearer 1231rfon2#$%$#"
                }) ;
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    // definir as configuracoes
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            return services;
        }
    }
}
