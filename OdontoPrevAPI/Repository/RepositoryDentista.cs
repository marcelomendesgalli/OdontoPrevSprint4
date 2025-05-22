using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;
using OdontoPrevAPI.Data;
using OdontoPrevAPI.Repository.Interface;

namespace OdontoPrevAPI.Repository
{
    public class RepositoryDentista : IDentistaRepository, IDisposable 
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryDentista()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        
        public async Task Excluir(Model.Dentista Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Dentista>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Model.Dentista>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Dentista>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Model.Dentista> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Dentista>().FindAsync(Id);
            }
        }
        
        public async Task Adicionar(Model.Dentista Objeto)
        {


            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Dentista>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }
        
        public async Task Atualizar(Model.Dentista Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Dentista>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
