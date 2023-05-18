namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;
    using System.Collections.Generic;
    using ProjectEON.Managers;

    public class EnemyParty : Party
    {
        public override List<UnitManager> GetComposedUnits()
        {
            return GameManager.Instance.CombatManager.EnemyPartyComposer.InFightUnitsManager.GetComposedUnits();
        }
    }
}