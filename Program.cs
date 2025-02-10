using Microsoft.EntityFrameworkCore;
using Ploomers_Advogados.Data;
using Ploomers_Advogados.Services;
using AutoMapper;
using Ploomers_Advogados.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Ploomers_Advogados.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar a string de conexão
var connectionString = builder.Configuration.GetConnectionString("AdvogadoConnection");

// Registrar o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDbContext<UsuarioDbContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Configuração do JWT
var key = Encoding.ASCII.GetBytes("ASFLKSDMGLM+654F65SD4F4FS65D4F65SD4FS6D54FWE65R4SD6F46F5G4BV6N54VBN");
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
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioDbContext>()
    .AddDefaultTokenProviders();


// Registrar repositórios e serviços
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IAdvogadoRepository, AdvogadoRepository>();
builder.Services.AddScoped<IAdvogadoService, AdvogadoService>();
builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();
builder.Services.AddScoped<IProcessoService, ProcessoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();



// Adicionar serviços de controle e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Ploomers",
        Version = "v1",
        Description = "API para gestão de advogados e processos. Essa API permite realizar operações sobre advogados, processos e usuários, utilizando autenticação JWT para segurança."
    });
    var xmlfile = "apiploomers.xml";
    var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
    options.IncludeXmlComments(xmlpath);

    // Configuração do esquema de autenticação JWT
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Por favor insira o token JWT. Exemplo: 'Bearer {seu_token}'"
    });

    // Aplica a segurança de autenticação a todas as operações
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
