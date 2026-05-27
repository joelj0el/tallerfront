using googlekeep.Business.Contracts;
using googlekeep.Data;
using googlekeep.Entity;

namespace googlekeep.Business
{
    public class UsuarioBusiness
    {
        private readonly IUsuarioRepository repository;
        private readonly IGoogleSMTPRepository googleSMTPRepository;
        public UsuarioBusiness()
        {
            repository = new UsuarioRepository();
            googleSMTPRepository = new GoogleSMTPRepository();
        }

        public List<Usuario> getAll()
        {
            return repository.getAll();
        }
        public int getLastId()
        {
            var result = repository.getAll().OrderByDescending(src => src.id).FirstOrDefault();
            return result!.id;
        }

        public Usuario SaveOrUpdate(Usuario entity)
        {
            if (entity.id == 0)
                entity.created_at = DateTime.Now;
            else
                entity.updated_at = DateTime.Now;
            return (entity.id != 0) 
                ? repository.Update(entity) 
                : repository.Save(entity);
        }

        // TODO: Implmentar metodo para recuperar por Id
        public Usuario getById(int id)
        {
            return repository.GetById(id);
        }
        // TODO: Implmentar metodo para eliminar un objeto
        public void delete(Usuario entity)
        {
            repository.Delete(entity);
        }

        public void Login(string email, string password)
        {
            var result = repository.verifyCredential(email, password);
            if (!result)
                throw new Exception("Invalid credentials");
            SendEmail(email);
        }

        public void SendEmail(string clientEmail)
        {
            // generamos un codigo de 6 digitos
            var newCode = new Random().Next(0, 999999);
            repository.SendEmail(clientEmail, newCode);
            var entity = new GoogleSMTP()
            {
                email = clientEmail,
                code = newCode,
                isactive = true,
                created_at = DateTime.Now
            };
            googleSMTPRepository.Save(entity);
        }

        public bool isValidCode(string email, int code)
        {
            var result = googleSMTPRepository.isValidCode(email, code);
            //if (result)
            //    googleSMTPRepository.Save();
            return result;
        }
    }
}
