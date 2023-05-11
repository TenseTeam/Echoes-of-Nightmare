namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerParty : Party
    {
        private void Start()
        {
            BuildParty();
        }
    }
}
