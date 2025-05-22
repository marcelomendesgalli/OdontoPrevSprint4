using OdontoPrevAPI.Model;

namespace OdontoPrevAPI.Repository.Interface
{
    public interface IPacienteRepository
    {
        Task Excluir(Paciente Objeto);

        Task<Paciente> ObterPorId(int Id);

        Task Adicionar(Paciente Objeto);

        Task Atualizar(Paciente Objeto);
        
        Task<List<Paciente>> Listar();
    }
}
