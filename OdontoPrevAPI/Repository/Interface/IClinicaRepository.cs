using OdontoPrevAPI.Model;

namespace OdontoPrevAPI.Repository.Interface
{
    public interface IClinicaRepository
    {
        Task Excluir(Clinica Objeto);

        Task<Clinica> ObterPorId(int Id);
        
        Task Adicionar(Clinica Objeto);

        Task Atualizar(Clinica Objeto);

        Task<List<Clinica>> Listar();
    }
}
