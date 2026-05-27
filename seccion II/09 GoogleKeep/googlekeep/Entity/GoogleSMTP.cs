namespace googlekeep.Entity
{
    public class GoogleSMTP: IEntity
    {
        public virtual int id { get; set; }
        public virtual int code { get; set; }
        public virtual string email { get; set; }
        public virtual bool isactive { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime? updated_at { get; set; }
    }
}
