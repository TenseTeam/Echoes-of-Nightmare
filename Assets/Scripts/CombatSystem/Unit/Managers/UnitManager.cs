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
    using ProjectEON.CombatSystem.Managers;

    [RequireComponent(typeof(Unit))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof (UnitAnimatorController))]
    [RequireComponent(typeof(UnitStatusEffects))]
    [RequireComponent(typeof(UnitAudioHandler))]
    public abstract class UnitManager : MonoBehaviour, IPooledObject
    {
        public event Action OnCriticalReceived;
        public event Action OnInitialize;
        public event Action OnUnitTurnStart;
        public event Action OnUnitTurnEnd;

        private SpriteRenderer _spriteRenderer; // This is not really needed because the animator controller override will override the sprite due the its animations

        public Unit Unit { get; private set; }
        public UnitData UnitData { get; private set; }
        public UnitTurns UnitTurns { get; private set; }
        public UnitStatusEffects UnitStatusEffects { get; private set; }
        public UnitAnimatorController UnitAnimatorController { get; private set; }
        public UnitAudioHandler UnitAudioHandler { get; private set; }
        public Pool RelatedPool { get; private set; }
        public Party Party { get; private set; }

        protected virtual void Awake()
        {
            TryGetComponent(out _spriteRenderer);
            TryGetComponent(out UnitAnimatorController unitAnimatorController);
            TryGetComponent(out Unit unit);
            TryGetComponent(out UnitTurns turns);
            TryGetComponent(out UnitStatusEffects unitStatusEffects);
            TryGetComponent(out UnitAudioHandler unitAudioHandler);

            UnitAudioHandler = unitAudioHandler;
            UnitAnimatorController = unitAnimatorController;
            Unit = unit;
            UnitTurns = turns;
            UnitStatusEffects = unitStatusEffects;
        }

        public virtual void Init(UnitData unitData, Party party, Pool pool)
        {
            Party = party;
            UnitData = unitData;
            _spriteRenderer.sprite = unitData.UnitSprite;
            AssociatePool(pool);
            Unit.Init(unitData.HitPoints, () => Dispose(), this);
            UnitAudioHandler.Init(unitData.GetHitClip);
            OnInitialize?.Invoke();
        }

        public void UnitTurnStart()
        {
            OnUnitTurnStart?.Invoke();
        }

        public void UnitTurnEnd()
        {
            OnUnitTurnEnd?.Invoke();
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