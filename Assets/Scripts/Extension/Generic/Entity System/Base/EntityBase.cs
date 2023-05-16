namespace Extension.EntitySystem
{
    using Extension.EntitySystem.Interfaces;
    using System;
    using UnityEngine;

    public class EntityBase : MonoBehaviour, IEntityVulnerable
    {
        [Header("Stats")]
        [SerializeField] protected float maxHitPoints;
        [SerializeField] protected float startingHitPoints;
        public float CurrentHitPoints { get; private set; }
        public bool IsAlive { get; private set; } = true;

        public delegate void HitPointsChangeHandler(float currentHitPoints, float maxHitPoints);
        public event HitPointsChangeHandler OnHitPointsChange;

        protected virtual void SetupHP()
        {
            CurrentHitPoints = startingHitPoints;

            if (CurrentHitPoints > startingHitPoints)
            {
                startingHitPoints = maxHitPoints;
                CurrentHitPoints = startingHitPoints;
            }

            OnHitPointsChange?.Invoke(CurrentHitPoints, maxHitPoints);
        }

        public virtual void TakeDamage(float hitDamage = 1f)
        {
            CurrentHitPoints -= Mathf.Abs(hitDamage);

            if (CurrentHitPoints <= 0.1f)
            {
                CurrentHitPoints = 0f;
                Death();
            }

            OnHitPointsChange?.Invoke(CurrentHitPoints, maxHitPoints);
        }

        public virtual void HealHitPoints(float healPoints)
        {
            IsAlive = true;
            CurrentHitPoints += Mathf.Abs(healPoints);

            if (CurrentHitPoints > maxHitPoints)
                CurrentHitPoints = maxHitPoints;

            OnHitPointsChange?.Invoke(CurrentHitPoints, maxHitPoints);
        }

        public virtual void Death()
        {
            IsAlive = false;
        }
    }
}