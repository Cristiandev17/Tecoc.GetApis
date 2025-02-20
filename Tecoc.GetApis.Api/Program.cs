using Tecoc.GetApis.Api.Services.Interfaces;
using Tecoc.GetApis.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tecoc.GetApis.Api.Utilities;

var MyAllowSpecificOrigins = Constans.MyAllowSpecificOrigins;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                      });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["jwt:Issuer"],
        ValidAudience = builder.Configuration["jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]))

    };

    options.UseSecurityTokenValidators = true;
}); ;

// Add services to the container.
builder.Services.AddScoped<IMarvelApiService, MarvelApiService>();
builder.Services.AddScoped<IChucknorrisApiService, ChucknorrisApiService>();
builder.Services.AddScoped<ICocktailApiService, CocktailApiService>();
builder.Services.AddScoped<IColombiaApiService, ColombiaApiService>();
builder.Services.AddScoped<IPokemonApiService, PokemonApiService>();
builder.Services.AddScoped<IRandomUserApiService, RandomUserApiService>();
builder.Services.AddScoped<IRickAndMortyApiService, RickAndMortyApiService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
