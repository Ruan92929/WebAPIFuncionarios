using Microsoft.EntityFrameworkCore;
using ProjetoWebAPI.Models;

namespace ProjetoWebAPI.Service.UserService
{
    public interface IUserRepository
    {
        public User Get(string username, string password);
        void Create(User user);
    }
}
