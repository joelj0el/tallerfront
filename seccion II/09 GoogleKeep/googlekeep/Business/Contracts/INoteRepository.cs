using googlekeep.Entity;

namespace googlekeep.Business.Contracts
{
    public interface INoteRepository: IGenericRepository<Note>
    {
        public IList<Note> getAll();
    }
}
