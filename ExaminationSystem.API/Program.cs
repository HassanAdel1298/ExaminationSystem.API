using Autofac.Extensions.DependencyInjection;
using Autofac;
using ExaminationSystem.API.VerticalSlicing.Common;
using System.Reflection;
using ExaminationSystem.API.VerticalSlicing.Common.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ExaminationSystem.API.VerticalSlicing.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common.Middlewares;
using Microsoft.OpenApi.Models;
using Autofac.Core;
using Microsoft.AspNetCore.Hosting;
using ExaminationSystem.VerticalSlicing.Features.Users.Register.Commands;


namespace ExaminationSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examination System API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. " +
                                    "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below." +
                                    "\r\n\r\nExample: \"Bearer abcdefghijklmnopqrstuvwxyz\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = JwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = JwtSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero, 
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSettings.Key))
                };
            });

            builder.Services.AddDbContext<Context>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
                builder.RegisterModule(new AutofacModule()));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly
                                            (typeof(RegisterUserCommand).Assembly));

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("MyPolicy", corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            MapperHelper.Mapper = app.Services.GetService<IMapper>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            

            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
