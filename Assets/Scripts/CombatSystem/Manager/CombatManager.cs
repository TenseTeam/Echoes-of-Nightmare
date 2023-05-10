namespace ProjectEON.CombatSystem.Manager
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.PartySystem;
    using System.Collections.Generic;

    public class CombatManager : Singleton<CombatManager>
    {
        [field: SerializeField, Header("Pools")]
        public UnitsPool UnitsPool { get; private set; }

        [field: SerializeField, Header("Party Builder")]
        public CombatPartyBuilder PartyBuilder { get; private set; }

        [SerializeField] private Transform _mainPartyParent, _oppenentPartyParent;

        [field: SerializeField, Header("Combat Turns Manager")]
        public CombatTurns TurnsManager { get; private set; }

        [field: SerializeField, Header("PartyTurns")]
        public PartyTurns FirstPartyTurns { get; private set; }
        [field: SerializeField]
        public PartyTurns SecondPartyTurns { get; private set; }

        public List<Unit> mainParty { get; private set; }
        public List<Unit> opponentParty { get; private set; }

        public void Begin(Party partyOne, Party partyTwo)
        {
            mainParty = PartyBuilder.BuildCombatants(partyOne, UnitsPool, _mainPartyParent, 1f);
            opponentParty = PartyBuilder.BuildCombatants(partyTwo, UnitsPool, _oppenentPartyParent, -1f);

            TurnsManager.InitStates(FirstPartyTurns, SecondPartyTurns, mainParty, opponentParty);
            TurnsManager.Begin();
        }
    }
}