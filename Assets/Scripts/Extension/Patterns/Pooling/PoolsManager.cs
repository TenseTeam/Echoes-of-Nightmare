namespace Extension.Patterns.ObjectPool
{
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Transform;
    using Extension.Patterns.ObjectPool.Interfaces;
    using Extension.Generic.Serializable;

    public class PoolsManager : MonoBehaviour
    {
        [field: SerializeField]
        public SerializableDictionary<int, string> Pools { get; private set; }
    }
}