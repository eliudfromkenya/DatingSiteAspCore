using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
//using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Models;
using DatingApp.API.Contracts;
using DatingApp.API.Helpers;
using DatingApp.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API {
  public class Startup {
    public Startup (IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices (IServiceCollection services) {
      services.AddDbContext<DataContext> (x => x.UseSqlite (@"Filename=DatingAppDb.db"));
      services.AddControllers ();
      services.AddCors ();
      services.AddScoped<LogUserActivity> ();
      services.Configure<CloudinarySettings> (Configuration.GetSection ("CloudinarySettings"));
      services.AddAutoMapper (typeof (AutoMapperProfiles));
      services.AddTransient<Seed> ();
      services.AddScoped<IAuthRepository, AuthRepository> ();
      services.AddScoped<IRepository, Repository> ();
      services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer (options => {
          options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Configuration.GetSection ("AppSettings:Token").Value)),
          ValidateIssuer = false,
          ValidateAudience = false
          };
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IWebHostEnvironment env, Seed seeder) {
      
      
      if (env.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
      } else {
        app.UseExceptionHandler (builder => {
          builder.Run (async context => {
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            var error = context.Features.Get<IExceptionHandlerFeature> ();
            if (error != null) {
              context.Response.AddApplicationError (error.Error.Message);
              await context.Response.WriteAsync (error.Error.Message);
            }
          });
        });
      }
      // try {
      //   Console.WriteLine ("writing");
      //   seeder.SeedUsers ();
      //   Console.WriteLine ("writing out");
      // } catch (System.Exception) { }

      app.UseCors (x => x.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());
      app.UseAuthentication ();
      app.UseHttpsRedirection ();

      app.UseRouting ();

      app.UseAuthorization ();

      app.UseEndpoints (endpoints => {
        endpoints.MapControllers ();
        endpoints.MapFallbackToController("Index", "Fallback");
      });
    }
  }
}