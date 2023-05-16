namespace ProjectEON.CombatSystem.Units
{
    using Extension.EntitySystem;
    using ProjectEON.SOData;
    using System;

    public class Unit : EntityBase
    {
        public event Action OnDeath;

        public virtual void Init(int hitPoints, Action onDeath)
        {
            maxHitPoints = hitPoints;
            startingHitPoints = hitPoints;
            SetupHP();
        }

        public override void Death()
        {
            base.Death();
            OnDeath.Invoke();
        }
    }
}
