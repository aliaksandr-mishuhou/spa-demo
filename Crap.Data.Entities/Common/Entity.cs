namespace Crap.Data.Entities.Common
{
    /// <summary>
    /// base entity with integer PK 
    /// </summary>
    public abstract class Entity : IEntity<int>
    {
        public int Id { get; set; }
    }
}
