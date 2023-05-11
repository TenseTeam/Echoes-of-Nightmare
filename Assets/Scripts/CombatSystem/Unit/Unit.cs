namespace ProjectEON.CombatSystem
{
    using Extension.EntitySystem;
    using Extension.Patterns.ObjectPool;
    using Extension.Patterns.ObjectPool.Interfaces;
    using ProjectEON.SOData;
    using UnityEngine;


    [RequireComponent(typeof(SpriteRenderer))]
    public class Unit : EntityBase, IPooledObject
    {
        public UnitData Data { get; private set; }
        private SpriteRenderer _spriteRenderer;

        public Pool RelatedPool { get; private set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Init(UnitData data, Pool associatedPool)
        {
            Data = data;
            maxHitPoints = data.hitPoints;
            startingHitPoints = maxHitPoints;
            _spriteRenderer.sprite = data.combatantSprite;
            AssociatePool(associatedPool);
            SetupHP();
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }
    }
}
