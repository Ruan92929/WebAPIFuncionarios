using ProjetoWebAPI.Models;

namespace ProjetoWebAPI.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        //Basicamente informamos o nosso método será um método Assíncrono que retornará um
        //ServiceResponse e esse ServiceResponse através do dado genérico passado, retornará uma
        //lista da entidade FuncionariosModel.
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();

        public string teste();
    
    }
}
