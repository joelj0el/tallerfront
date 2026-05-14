using googlekeep.Business.Contracts;
using googlekeep.Entity;

namespace googlekeep.Data
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public IList<Note> getAll()
        {
            var result = Session.QueryOver<Note>().List();
            return result;
        }
    }
}
