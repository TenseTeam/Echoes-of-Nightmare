namespace Extension.Patterns.ObjectPool.Interfaces
{
    using Extension.Patterns.ObjectPool;

    public interface IPooledObject
    {
        Pool RelatedPool { get; }

        /// <summary>
        /// Associates the Object with a <see cref="Pool"/>.
        /// </summary>
        /// <param name="associatedPool"></param>
        void AssociatePool(Pool associatedPool);

        /// <summary>
        /// Disposes the object and returns it to the <see cref="Pool"/>.
        /// </summary>
        void DisposeUnit();
    }
}