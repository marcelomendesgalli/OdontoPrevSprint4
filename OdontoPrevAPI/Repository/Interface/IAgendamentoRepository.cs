using OdontoPrevAPI.Model;

namespace OdontoPrevAPI.Repository.Interface
{
    public interface IAgendamentoRepository
    {
        Task Excluir(Agendamento Objeto);

        Task<Agendamento> ObterPorId(int Id);
        
        Task Adicionar(Agendamento Objeto);

        Task Atualizar(Agendamento Objeto);

        Task<List<Agendamento>> Listar();
    }
}
