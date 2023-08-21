using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebAPI.Models;
using ProjetoWebAPI.Service.FuncionarioService;

namespace ProjetoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionario() 
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());   
        }

        [HttpGet("teste")]
        public IActionResult Teste()
        {
            var resultado = _funcionarioInterface.teste();
            return Ok(resultado);
        }


    }
}
