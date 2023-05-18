namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.Managers;
    using System.Collections.Generic;

    public class PlayerParty : Party
    {
        public override List<UnitManager> GetComposedUnits()
        {
            return GameManager.Instance.CombatManager.PlayerPartyComposer.InFightUnitsManager.GetComposedUnits();
        }
    }
}