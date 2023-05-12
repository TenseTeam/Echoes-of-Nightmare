namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData;
    using UnityEngine;
    using ProjectEON.CombatSystem.Manager;

    public class PlayerParty : Party
    {
        public override void BuildParty()
        {
            base.BuildParty();
        }

        protected override void GenerateUnit(UnitData unitData)
        {
            GameObject pooledUnit = CombatManager.Instance.PlayerUnitsPool.Get();
            pooledUnit.SetActive(false);

            if (pooledUnit.TryGetComponent(out PlayerUnit unit))
            {
                if(unit.TryGetComponent(out UnitHand unitHand))
                {
                    unit.Init(unitData, CombatManager.Instance.PlayerUnitsPool, unitHand);
                    Units.Add(unit);
                }
            }
        }

#if DEBUG
        [ContextMenu("Build Party")]
        public void DebugBuildParty()
        {
            BuildParty();
        }
#endif
    }
}
