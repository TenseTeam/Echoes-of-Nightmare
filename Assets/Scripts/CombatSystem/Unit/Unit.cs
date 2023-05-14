namespace ProjectEON.CombatSystem.Units
{
    using Extension.EntitySystem;
    using Extension.Patterns.ObjectPool;
    using Extension.Patterns.ObjectPool.Interfaces;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.SOData;
    using UnityEngine;
    using UnityEngine.EventSystems;

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

        public virtual void Init(UnitData data, Pool associatedPool)
        {
            Data = data;
            maxHitPoints = data.HitPoints;
            startingHitPoints = maxHitPoints;
            _spriteRenderer.sprite = data.UnitSprite;
            AssociatePool(associatedPool);
            SetupHP();
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public override void Death()
        {
            Dispose();
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }
    }
}
