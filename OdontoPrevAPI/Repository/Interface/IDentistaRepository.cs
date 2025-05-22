using OdontoPrevAPI.Model;

namespace OdontoPrevAPI.Repository.Interface
{
    public interface IDentistaRepository
    {
        Task Excluir(Dentista Objeto);

        Task<Dentista> ObterPorId(int Id);
        
        Task Adicionar(Dentista Objeto);

        Task Atualizar(Dentista Objeto);

        Task<List<Dentista>> Listar();
    }
}
