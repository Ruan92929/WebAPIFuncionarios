using ProjetoWebAPI.Service.FuncionarioService;
using ProjetoWebAPI.Service.TokenService.Authentication;
using ProjetoWebAPI.Service.UserService;

namespace ProjetoWebAPI.Config
{
    public static class DependecyInjectorExtensions
    {
        public static IServiceCollection AddCoreDepencies(this IServiceCollection services)
        {
            services.AddScoped<IFuncionarioInterface, FuncionarioRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<AuthService>();

            return services;
        }
    }
}
