using ProjetoWebAPI.Models;
using ProjetoWebAPI.Service.UserService;
using static Azure.Core.HttpHeader;

namespace ProjetoWebAPI.Service.TokenService.Authentication
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string userName, string password)
        {

            if (string.IsNullOrEmpty(password))
                throw new Exception("Senha inválida!");

            var user = _userRepository.Get(userName, password);

            if (userName == null)
                throw new Exception("Usuário inválido");

            var hashPassword = Encryption.HashSha1(password);

            if (user.Password != hashPassword)
                throw new Exception("Password inválido");

            return user;
        }

    }
}
