namespace ProjectEON.CombatSystem.PartyComposers
{
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.SOData;
    using UnityEngine;


    public class PlayerPartyBattleComposer : PartyBattleComposer
    {
        protected override void GenerateUnit(Unit unit, UnitData unitData, Vector3 position)
        {
            //base.GenerateUnit(unit, unitData, position);
            if (unit.TryGetComponent(out UnitHand unitHand))
            {
                ((PlayerUnit)unit).Init(unitData, Pool, unitHand);
                ComposedUnits.Add(unit);
                SetUnitBattleName(unit);
                SetUnitBattlePosition(unit, position);
            }
        }
    }
}