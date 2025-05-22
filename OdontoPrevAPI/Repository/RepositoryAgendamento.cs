using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;
using OdontoPrevAPI.Data;
using OdontoPrevAPI.Repository.Interface;

namespace OdontoPrevAPI.Repository
{
    public class RepositoryAgendamento : IAgendamentoRepository, IDisposable 
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryAgendamento()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        
        public async Task Excluir(Model.Agendamento Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Agendamento>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }
        public async Task<List<Model.Agendamento>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Agendamento>().AsNoTracking().ToListAsync();
            }
        }
        public async Task<Model.Agendamento> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Agendamento>().FindAsync(Id);
            }
        }
        public async Task Adicionar(Model.Agendamento Objeto)
        {
            
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Agendamento>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }
        public async Task Atualizar(Model.Agendamento Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Agendamento>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
