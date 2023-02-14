using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolves.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

//Log.Logger = new LoggerConfiguration()
//            .MinimumLevel.Information()
//            .WriteTo.AzureApp(opt =>
//            {
//                opt.InstrumentationKey = "YOUR_INSTRUMENTATION_KEY";
//            })
//            .CreateLogger();
// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
IConfiguration configuration = builder.Configuration;


builder.Services.AddControllers(
 options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});


builder.Services.AddDependencyResolvers(new ICoreModule[] {
    new CoreModule(),
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHealthChecks()
 .AddCheck("self", () => HealthCheckResult.Healthy());




builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllDev",
    policy =>
           {
               policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
           });
    options.AddPolicy(name: "dene", policy =>
    {
        policy.WithOrigins("https://anttaxi.mobilulasim.com").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.AzureApp()
    .CreateLogger();

Host.CreateDefaultBuilder(args)
    .UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("dene");

app.MapControllers();
app.UseRouting();
app.MapHealthChecks("/health");
app.Run();
