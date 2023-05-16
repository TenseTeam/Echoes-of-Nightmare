namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;
    using System.Collections.Generic;

    public class EnemyParty : Party
    {
        public override List<UnitManager> GetComposedUnits()
        {
            return CombatManager.Instance.EnemyPartyComposer.InFightUnitsManager.GetComposedUnits();
        }
    }
}