using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;

using MuniBot_BackEnd.Application.Interface;
using MuniBot_BackEnd.Application.Main;
using MuniBot_BackEnd.Domain.Core;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Data;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Infrastructure.Repository;
using MuniBot_BackEnd.Transversal.Common;
using MuniBot_BackEnd.Transversal.Mapper;
using MuniBot_BackEnd.Transversal.Logging;

using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Services.WebApi.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;

namespace Services.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();


            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();


            services.AddScoped<IGeneralDetApplication, GeneralDetApplication>();
            services.AddScoped<IGeneralDetDomain, GeneralDetDomain>();
            services.AddScoped<IGeneralDetRepository, GeneralDetRepository>();

            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IUsuarioDomain, UsuarioDomain>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IContribuyenteApplication, ContribuyenteApplication>();
            services.AddScoped<IContribuyenteDomain, ContribuyenteDomain>();
            services.AddScoped<IContribuyenteRepository, ContribuyenteRepository>();

            services.AddScoped<ISolicitudLicenciaApplication, SolicitudLicenciaApplication>();
            services.AddScoped<ISolicitudLicenciaDomain, SolicitudLicenciaDomain>();
            services.AddScoped<ISolicitudLicenciaRepository, SolicitudLicenciaRepository>();

            services.AddScoped<IEstablecimientoClaseApplication, EstablecimientoClaseApplication>();
            services.AddScoped<IEstablecimientoClaseDomain, EstablecimientoClaseDomain>();
            services.AddScoped<IEstablecimientoClaseRepository, EstablecimientoClaseRepository>();

            services.AddScoped<IEstablecimientoSubclaseApplication, EstablecimientoSubclaseApplication>();
            services.AddScoped<IEstablecimientoSubclaseDomain, EstablecimientoSubclaseDomain>();
            services.AddScoped<IEstablecimientoSubclaseRepository, EstablecimientoSubclaseRepository>();

            services.AddScoped<IEstablecimientoCategoriaApplication, EstablecimientoCategoriaApplication>();
            services.AddScoped<IEstablecimientoCategoriaDomain, EstablecimientoCategoriaDomain>();
            services.AddScoped<IEstablecimientoCategoriaRepository, EstablecimientoCategoriaRepository>();

            services.AddScoped<IReniecApplication, ReniecApplication>();
            services.AddScoped<IReniecDomain, ReniecDomain>();
            services.AddScoped<IReniecRepository, ReniecRepository>();

            services.AddScoped<IUbigeoApplication, UbigeoApplication>();
            services.AddScoped<IUbigeoDomain, UbigeoDomain>();
            services.AddScoped<IUbigeoRepository, UbigeoRepository>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;


            // Validar el token al momento de la petición
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userId = int.Parse(context.Principal.Identity.Name);
                        return Task.CompletedTask;
                    },

                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false; //true cuando trabajemos con HTTPS
                x.SaveToken = false; //No ncesitamos guardar el token
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,
                    ValidateLifetime = true, //Validar el tiempo de vida del token
                    ClockSkew = TimeSpan.Zero //Validar si hay alguna diferencia entre las horas (0=No hay diferencia)
                };
            });


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PLATSM Technology Services API Market",
                    Description = "ASP.NET Core Web API",
                    TermsOfService = new Uri("https://platsm.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "UPC - PLATSM",
                        Email = "platsm@upc.edu.pe",
                        Url = new Uri("https://platsm.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under UPC",
                        Url = new Uri("https://platsm.com/licence")
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme // Bearer significa que nuestra API soporta token del tipo portador
                {
                    Description = "Authorization by API key.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API MuniBot V1");
            });

            //app.UseSwaggerUI(typeof(Startup).GetTypeInfo().Assembly,new SwaggerUiOwinSetting());

            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
