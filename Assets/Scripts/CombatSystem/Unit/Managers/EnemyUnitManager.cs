namespace ProjectEON.CombatSystem.Units
{
    using UnityEngine;

    [RequireComponent(typeof(EnemyUnitAI))]
    public class EnemyUnitManager : UnitManager
    {
        public EnemyUnitAI EnemyAI { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            EnemyAI = GetComponent<EnemyUnitAI>();
        }
    }
}