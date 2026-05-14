using googlekeep.Business.Contracts;
using googlekeep.Data;
using googlekeep.Entity;

namespace googlekeep.Business
{
    public class NoteBusiness
    {
        private readonly INoteRepository repository;
        public NoteBusiness()
        {
            repository = new NoteRepository();
        }

        public List<Note> getAll()
        {
            return repository.getAll().ToList();
        }
        //public int getLastId()
        //{
        //    var result = repository.getAll().OrderByDescending(src => src.id).FirstOrDefault();
        //    return result!.id;
        //}

        public Note SaveOrUpdate(Note entity)
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
        public Note getById(int id)
        {
            return repository.GetById(id);
        }
        // TODO: Implmentar metodo para eliminar un objeto
        public void delete(Note entity)
        {
            repository.Delete(entity);
        }
    }
}
