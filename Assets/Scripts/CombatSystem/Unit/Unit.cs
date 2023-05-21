namespace ProjectEON.CombatSystem.Units
{
    using System;
    using UnityEngine;
    using Extension.EntitySystem;

    //[RequireComponent(typeof(UnitManager))]
    public class Unit : EntityBase
    {
        public event Action OnDeath;
        private UnitManager _unitManager;

        public virtual void Init(int hitPoints, Action onDeath, UnitManager unitManager)
        {
            maxHitPoints = hitPoints;
            startingHitPoints = hitPoints;
            OnDeath = onDeath;
            _unitManager = unitManager;
            SetupHP();
        }

        public override void Death()
        {
            base.Death();
            OnDeath?.Invoke();
        }

        public override void TakeDamage(float hitDamage = 1)
        {
            hitDamage -= hitDamage / 100 * _unitManager.UnitStatusEffects.CurrentDamageReduction;
            base.TakeDamage(Mathf.Round(hitDamage));
        }
    }
}
