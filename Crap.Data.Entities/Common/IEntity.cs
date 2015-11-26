namespace Crap.Data.Entities.Common
{
    public interface IEntity<T> where T : struct 
    {
        T Id { get; set;}
    }
}
