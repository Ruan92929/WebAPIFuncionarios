using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebAPI.Models;
using ProjetoWebAPI.Service.Token;
using ProjetoWebAPI.Service.TokenService.Authentication;
using ProjetoWebAPI.Service.UserService;

namespace ProjetoWebAPI.Controllers
{
    [ApiController]
    [Route("V1")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _IuserRepository;
        private readonly AuthService _AuthService;
        public UserController(IUserRepository IuserRepository, AuthService AuthService)
        {
            _IuserRepository = IuserRepository;
            _AuthService = AuthService;
        }


        [HttpPost]
        [Route("LoginV1")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {

            var User = _AuthService.Authenticate(model.Username, model.Password);

            var token = TokenService.GenerateToken(User);


            return new {token = token };
        }

        [HttpPost]
        [Route("CreateUserV1")]
        public IActionResult CreateUser([FromBody] User model)
        {
            try
            {
                _IuserRepository.Create(model);

                return Ok(new { message = "Usuário criado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
