namespace Extension.Patterns.ObjectPool.Interfaces
{
    using Extension.Patterns.ObjectPool;

    public interface IPooledObject
    {
        Pool RelatedPool { get; }

        void AssociatePool(Pool associatedPool);

        /// <summary>
        /// Dispose the object and return it to the pool.
        /// </summary>
        void DisposeUnit();
    }
}