namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;
    using System.Collections.Generic;

    public class EnemyParty : Party
    {
        private void Start()
        {
            AssociateInFightUnitsManager(CombatManager.Instance.EnemyPartyComposer.InFightUnitsManager);
        }
    }
}