using FluentNHibernate.Mapping;
using googlekeep.Entity;

namespace googlekeep.Mappings
{
    public class NoteMap: ClassMap<Note>
    {
        public NoteMap()
        {
            Table("note");
            Id(x => x.id).Column("note_id")
                .GeneratedBy.Sequence("note_note_id_seq")
                .UnsavedValue(0);
            Map(x => x.title);
            Map(x => x.content);
            Map(x => x.activo);
            Map(x => x.created_at);
            Map(x => x.updated_at).Nullable();
        }
    }
}
