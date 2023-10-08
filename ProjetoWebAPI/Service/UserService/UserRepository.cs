using System.Collections.Generic;
using System.Linq;
using ProjetoWebAPI.DataContext;
using ProjetoWebAPI.Models;
using ProjetoWebAPI.Service.TokenService.Authentication;

namespace ProjetoWebAPI.Service.UserService
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (_context.Usuários.Any(x => x.Username == user.Username))
            {
                throw new InvalidOperationException("Já existe um usuário com esse nome de usuário.");
            }

            user.Password = Encryption.HashSha1(user.Password);
            _context.Usuários.Add(user);
            _context.SaveChanges();
        }


        public User Get(string username, string password)
        {
            // Converta a senha fornecida para o formato de hash SHA-1
            string hashedPassword = Encryption.HashSha1(password);

            // Verifique o usuário com o nome de usuário e senha criptografada
            var user = _context.Usuários.FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);

            return user;
        }


    }
}
