namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.Units;
    using System.Collections.Generic;

    public class PlayerParty : Party
    {
        private void Start()
        {
            AssociateInFightUnitsManager(CombatManager.Instance.PlayerPartyComposer.InFightUnitsManager);
        }
    }
}