using googlekeep.Business.Contracts;
using googlekeep.Entity;

namespace googlekeep.Data
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public List<Usuario> getAll()
        {
            var result = Session.Query<Usuario>().ToList();
            return result;
        }
    }
}
