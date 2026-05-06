using googlekeep.Business.Contracts;
using googlekeep.Data;
using googlekeep.Entity;

namespace googlekeep.Business
{
    public class UsuarioBusiness
    {
        private readonly IUsuarioRepository repository;
        public UsuarioBusiness()
        {
            repository = new UsuarioRepository();
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

        // TODO: Implmentar metodo para eliminar un objeto
    }
}
