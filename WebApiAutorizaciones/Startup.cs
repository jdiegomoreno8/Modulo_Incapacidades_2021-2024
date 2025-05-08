using LibreriasAutorizaciones.Modelos.DTO;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ServiciosAutorizaciones.Autenticacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAutorizaciones.Middleware;

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApiAutorizaciones
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
            services.AddControllers();

            //services.AddTransient<IAlbumesService, AlbumesService>();
            IoC.AddDependency(services);

            //services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            //var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();

            //services.AddScoped<IAutorizacionTokenServicio, AutorizacionTokenServicio>();
            services.AddScoped<IUsuarioAutenticadoServicio, UsuarioAutenticadoServicio>();

            //SymmetricSecurityKey signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Security"]));

            //string authenticationProviderKey = Configuration["JWT:AuthenticationProviderKey"];
            //services.AddAuthentication(option =>
            //{
            //    option.DefaultAuthenticateScheme = authenticationProviderKey;
            //    option.DefaultChallengeScheme = authenticationProviderKey;
            //})
            //    .AddJwtBearer(authenticationProviderKey, options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = signInKey,
            //            ValidateIssuer = true,
            //            ValidIssuer = Configuration["JWT:Issuer"],
            //            ValidateAudience = true,
            //            ValidAudience = Configuration["JWT:Audience"],
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            RequireExpirationTime = true
            //        };
            //    });

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
            //        ValidIssuer = token.Issuer,
            //        ValidAudience = token.Audience,
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,
            //    builder =>
            //    {
            //        builder.WithOrigins("http://localhost:44384",
            //                            "http://localhost:4200"
            //                            )
            //                            .AllowAnyHeader()
            //                            .AllowAnyMethod();
            //    });
            //});
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin", builder => {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
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

            app.UseHttpsRedirection();

            app.UseRouting();

           
            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
