namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;
    using System.Collections.Generic;

    public class EnemyParty : Party
    {
        public override List<Unit> GetComposedUnits()
        {
            return CombatManager.Instance.EnemyPartyComposer.ComposedUnits;
        }
    }
}