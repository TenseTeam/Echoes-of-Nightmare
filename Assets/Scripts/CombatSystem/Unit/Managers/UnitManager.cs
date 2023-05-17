namespace ProjectEON.CombatSystem.Units
{
    using System;
    using UnityEngine;
    using Extension.Patterns.ObjectPool;
    using Extension.Patterns.ObjectPool.Interfaces;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using System.Collections;

    [RequireComponent(typeof(Unit))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class UnitManager : MonoBehaviour, IPooledObject
    {
        private SpriteRenderer _spriteRenderer;
        public Unit Unit { get; private set; }
        public UnitData UnitData { get; private set; }
        public UnitTurns UnitTurns { get; private set; }
        public Pool RelatedPool { get; private set; }
        public Party Party { get; private set; }

        public event Action OnCriticalReceived;

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

        public void ReceiveCritical()
        {
            OnCriticalReceived?.Invoke();
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Dispose()
        {
            Party.GetComposedUnits().Remove(this); // Remove from the composed unit list this one.
            StartCoroutine(WaitDisposeRoutine());
        }

        private IEnumerator WaitDisposeRoutine()
        {
            yield return new WaitForSeconds(1.5f);
            RelatedPool.Dispose(gameObject);
        }
    }
}