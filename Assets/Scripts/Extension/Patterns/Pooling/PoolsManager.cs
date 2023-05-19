namespace Extension.Patterns.ObjectPool
{
    using UnityEngine;
    using Extension.Generic.Serializable;

    public class PoolsManager : MonoBehaviour
    {
        [field: SerializeField]
        public SerializableDictionary<string, Pool> Pools { get; private set; }
    }
}