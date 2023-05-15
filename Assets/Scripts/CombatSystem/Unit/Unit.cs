namespace ProjectEON.CombatSystem.Units
{
    using Extension.EntitySystem;
    using Extension.Patterns.ObjectPool;
    using Extension.Patterns.ObjectPool.Interfaces;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using UnityEngine;

    [RequireComponent(typeof(SpriteRenderer), typeof(UnitTurns))]
    public class Unit : EntityBase, IPooledObject
    {
        public UnitData Data { get; private set; }
        private SpriteRenderer _spriteRenderer;
        public Pool RelatedPool { get; private set; }
        public UnitTurns UnitTurns { get; private set; }
        public Party RelatedParty { get; private set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            UnitTurns = GetComponent<UnitTurns>();
        }

        public virtual void Init(UnitData data, Party relatedParty, Pool associatedPool)
        {
            Data = data;
            maxHitPoints = data.HitPoints;
            startingHitPoints = maxHitPoints;
            _spriteRenderer.sprite = data.UnitSprite;
            RelatedParty = relatedParty;
            AssociatePool(associatedPool);
            SetupHP();
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public override void Death()
        {
            base.Death();
            Dispose();
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }
    }
}
