namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.Units;
    using System.Collections.Generic;

    public class PlayerParty : Party
    {
        public override List<UnitManager> GetComposedUnits()
        {
            return CombatManager.Instance.PlayerPartyComposer.InFightUnitsManager.GetComposedUnits();
        }
    }
}