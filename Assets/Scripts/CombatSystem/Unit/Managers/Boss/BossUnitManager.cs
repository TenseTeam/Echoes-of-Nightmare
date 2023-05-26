namespace ProjectEON.CombatSystem.Units
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Unit.Managers.Boss;
    using Extension.Patterns.ObjectPool;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;

    [RequireComponent(typeof(BossPhasesManager))]
    public class BossUnitManager : EnemyUnitManager
    {
        private BossPhasesManager _bossPhases;

        protected override void Awake()
        {
            base.Awake();
            TryGetComponent(out _bossPhases);
        }

        public override void Init(UnitData bossData, Party party, Pool pool)
        {
            base.Init(bossData, party, pool);
            _bossPhases.Init(this, bossData as BossData);
        }

        /// <summary>
        /// Reinitializes this unit.
        /// </summary>
        /// <param name="bossData">Data of the boss.</param>
        public void ReInit(UnitData bossData)
        {
            base.Init(bossData, Party, RelatedPool);
        }

        public override void DisposeUnit()
        {
            UnitStatusEffects.ExitRemoveAllStatusEffects();

            if(_bossPhases.HasNoMorePhases)
            {
                base.DisposeUnit();
                // Here Goes the End of the game
                return;
            }

            _bossPhases.NextPhase();
        }
    }
}