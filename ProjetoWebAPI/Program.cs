using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoWebAPI;
using ProjetoWebAPI.Config;
using ProjetoWebAPI.DataContext;
using ProjetoWebAPI.Service.FuncionarioService;
using ProjetoWebAPI.Service.Token;
using ProjetoWebAPI.Service.TokenService.Authentication;
using ProjetoWebAPI.Service.UserService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Como desencriptar o token
var key = Encoding.ASCII.GetBytes(TokenService.SECRETKEY);

//Incluindo esquema de autênticação que esta sendo utilizado.
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Configurando para cliente conseguir colcoar o Token no swagger.
builder.Services.AddSwaggerConfiguration();

//quando for feita uma injeção de depencia do IfuncionarioInterface deverá ser utilizado os métodos de dentro do funcionarioServer.

builder.Services.AddCoreDepencies();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");

        // Adicione o esquema de segurança JWT ao Swagger UI
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
    });
}

app.UseHttpsRedirection();

//Necessário incluir caso queira authenticar a API, sempre antes do authorization.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
