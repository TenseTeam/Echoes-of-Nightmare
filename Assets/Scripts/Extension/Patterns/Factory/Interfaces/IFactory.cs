namespace Extension.Patterns.Factory.Interfaces
{
    public interface IFactory<T>
    {
        T Construct();
    }
}