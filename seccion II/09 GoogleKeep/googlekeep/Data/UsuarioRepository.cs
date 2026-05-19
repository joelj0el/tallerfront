using googlekeep.Business.Contracts;
using googlekeep.Entity;

namespace googlekeep.Data
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public List<Usuario> filterByName(string data)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> getAll()
        {
            var result = Session.Query<Usuario>().ToList();
            return result;
        }

        public bool verifyCredential(string email, string password)
        {
            var result = Session.QueryOver<Usuario>()
                .Where(src => src.password.ToUpper() == password && src.email.ToUpper() == email);
            return result != null;
        }
    }
}
