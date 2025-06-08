namespace JsonDB.Models
{
    public  abstract class BaseEntity
    {
        public int Iint { get; set; }
        public abstract string GetInfo();
    }
}
