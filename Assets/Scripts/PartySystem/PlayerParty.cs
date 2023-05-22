namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.Managers;
    using System.Collections.Generic;

    public class PlayerParty : Party
    {
        private void Start()
        {
            AssociateInFightUnitsManager(GameManager.Instance.CombatManager.PlayerPartyComposer.InFightUnitsManager);
        }
    }
}