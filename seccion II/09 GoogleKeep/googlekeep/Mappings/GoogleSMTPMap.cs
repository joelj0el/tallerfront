using FluentNHibernate.Mapping;
using googlekeep.Entity;

namespace googlekeep.Mappings
{
    public class GoogleSMTPMap: ClassMap<GoogleSMTP>
    {
        public GoogleSMTPMap()
        {
            Table("googlesmtp");
            Id(x => x.id).Column("google_id")
                .GeneratedBy.Sequence("googlesmtp_google_id_seq")
                .UnsavedValue(0);
            Map(x => x.code).Column("code").CustomType<int>();
            Map(x => x.email);
            Map(x => x.isactive);
            Map(x => x.created_at);
            Map(x => x.updated_at).Nullable();
        }
    }
}
