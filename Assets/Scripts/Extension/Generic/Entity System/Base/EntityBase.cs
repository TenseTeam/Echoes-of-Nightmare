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

        /// <summary>
        /// On hit points change Action event delegate.
        /// <code><see cref="(T1)"/> as The hit points change receiver.</code>
        /// <code><see cref="(T2)"/> as The current hit points.</code>
        /// <code><see cref="(T3)"/> as The maximum hit points.</code>
        /// </summary>
        public event Action<float, float, float> OnHitPointsChange;

        /// <summary>
        /// On hit points setup Action event delegate.
        /// <code><see cref="(T1)"/> as The current hit points.</code>
        /// <code><see cref="(T2)"/> as The maximum hit points.</code>
        /// </summary>
        public event Action<float, float> OnHitPointsSetUp;

        protected virtual void SetupHP()
        {
            CurrentHitPoints = startingHitPoints;

            if (CurrentHitPoints > startingHitPoints)
            {
                startingHitPoints = maxHitPoints;
                CurrentHitPoints = startingHitPoints;
            }

            OnHitPointsSetUp?.Invoke(CurrentHitPoints, maxHitPoints);
        }

        public virtual void TakeDamage(float hitDamage = 1f)
        {
            CurrentHitPoints -= Mathf.Abs(hitDamage);

            if (CurrentHitPoints <= 0.1f)
            {
                CurrentHitPoints = 0f;
                Death();
            }

            OnHitPointsChange?.Invoke(hitDamage, CurrentHitPoints, maxHitPoints);
        }

        public virtual void HealHitPoints(float healPoints)
        {
            IsAlive = true;
            CurrentHitPoints += Mathf.Abs(healPoints);

            if (CurrentHitPoints > maxHitPoints)
                CurrentHitPoints = maxHitPoints;

            OnHitPointsChange?.Invoke(healPoints, CurrentHitPoints, maxHitPoints);
        }

        public virtual void Death()
        {
            IsAlive = false;
        }
    }
}