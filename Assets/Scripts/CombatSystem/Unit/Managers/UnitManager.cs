namespace ProjectEON.CombatSystem.Units
{
    using Extension.Patterns.ObjectPool;
    using Extension.Patterns.ObjectPool.Interfaces;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using Unity.VisualScripting;
    using UnityEngine;

    [RequireComponent(typeof(Unit))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class UnitManager : MonoBehaviour, IPooledObject
    {
        private SpriteRenderer _spriteRenderer;
        public Unit Unit { get; private set; }
        public UnitData UnitData { get; private set; }

        [field: SerializeField]
        public UnitTurns UnitTurns { get; private set; }
        public Pool RelatedPool { get; private set; }
        public Party Party { get; private set; }

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            Unit = GetComponent<Unit>();
            UnitTurns = GetComponent<UnitTurns>();
        }

        public virtual void Init(UnitData unitData, Party party, Pool pool)
        {
            Party = party;
            UnitData = unitData;
            _spriteRenderer.sprite = unitData.UnitSprite;
            AssociatePool(pool);
            Unit.Init(unitData.HitPoints, () => Dispose());
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