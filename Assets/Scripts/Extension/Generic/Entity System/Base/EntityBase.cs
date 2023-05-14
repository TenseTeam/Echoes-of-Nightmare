namespace Extension.EntitySystem
{
    using Extension.EntitySystem.Interfaces;
    using UnityEngine;

    public class EntityBase : MonoBehaviour, IEntityVulnerable
    {
        [Header("Stats")]
        [SerializeField] protected float maxHitPoints;
        [SerializeField] protected float startingHitPoints;

        protected float hitPoints;
     
        public bool IsAlive { get;  private set; }

        protected virtual void SetupHP()
        {
            hitPoints = startingHitPoints;

            if (hitPoints > startingHitPoints)
            {
                startingHitPoints = maxHitPoints;
                hitPoints = startingHitPoints;
            }
        }

        public virtual void TakeDamage(float hitDamage = 1f)
        {
            hitPoints -= Mathf.Abs(hitDamage);

            if (hitPoints <= 0.1f)
            {
                hitPoints = 0f;
                Death();
            }
        }

        public virtual void HealHitPoints(float healPoints)
        {
            IsAlive = true;
            hitPoints += Mathf.Abs(healPoints);

            if (hitPoints > maxHitPoints)
                hitPoints = maxHitPoints;
        }

        public virtual void Death()
        {
            IsAlive = false;
            Destroy(gameObject);
        }
    }
}