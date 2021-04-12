namespace DIO.Series
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}