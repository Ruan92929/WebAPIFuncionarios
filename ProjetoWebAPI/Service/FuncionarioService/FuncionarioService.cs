using ProjetoWebAPI.DataContext;
using ProjetoWebAPI.Models;

namespace ProjetoWebAPI.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {

        //Injeção de dependência
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            //Primeiro iremos criar uma instânciação do tipo recebido na classe.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if(serviceResponse.Dados.Count == 0 )
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public string teste()
        {
            return "teste";
        }
    }
}
