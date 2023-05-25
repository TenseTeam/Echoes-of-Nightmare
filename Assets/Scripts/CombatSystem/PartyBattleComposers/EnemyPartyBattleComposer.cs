namespace ProjectEON.CombatSystem.PartyComposers
{
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using UnityEngine;

    public class EnemyPartyBattleComposer : PartyBattleComposer<UnitManager>
    {
        [SerializeField]
        protected UnitsPool BossPool;

        protected override GameObject PoolUnit(UnitData unitData)
        {
            if (unitData is BossData)
                return BossPool.Get();
            return base.PoolUnit(unitData);
        }
    }
}