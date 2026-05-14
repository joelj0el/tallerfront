namespace googlekeep.Entity
{
    public class Note: IEntity
    {
        public virtual int id { get; set; }
        public virtual string title { get; set; }
        public virtual string content { get; set; }
        public virtual bool activo { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime? updated_at { get; set; }
    }
}
