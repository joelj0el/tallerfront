using googlekeep.Entity;

namespace googlekeep.Business.Contracts
{
    public interface IUsuarioRepository: IGenericRepository<Usuario>
    {
        // agregar mis metodos
        List<Usuario> getAll();

        List<Usuario> filterByName(string data);
        bool verifyCredential(string email, string password);
        void SendEmail(string clientEmail, int newCode);
    }
}
