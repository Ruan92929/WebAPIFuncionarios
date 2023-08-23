using ProjetoWebAPI.Models;

namespace ProjetoWebAPI.Service.FuncionarioService
{
    public interface IFuncionarioInterface 
    {
        //Basicamente informamos o nosso método será um método Assíncrono que retornará um
        //ServiceResponse e esse ServiceResponse através do dado genérico passado, retornará uma
        //lista da entidade FuncionariosModel.
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);



    }
}
