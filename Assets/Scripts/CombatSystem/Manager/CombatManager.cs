namespace ProjectEON.CombatSystem.Manager
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.PartySystem;

    public class CombatManager : Singleton<CombatManager>
    {
        [field: SerializeField, Header("Pools")]
        public UnitsPool UnitsPool { get; private set; }

        [field: SerializeField, Header("Party Builders")]
        public CombatPartyComposer MainPartyBuilder { get; private set; }
        [field: SerializeField]
        public CombatPartyComposer OpponentPartyBuilder { get; private set; }

        [field: SerializeField, Header("Combat Turns Manager")]
        public CombatTurns TurnsManager { get; private set; }

        [field: SerializeField, Header("PartyTurns")]
        public PartyTurns FirstPartyTurns { get; private set; }
        [field: SerializeField]
        public PartyTurns SecondPartyTurns { get; private set; }

        public void Begin(Party mainParty, Party opponentParty)
        {
            opponentParty.BuildParty();
            MainPartyBuilder.ComposeFightUnits(mainParty);
            OpponentPartyBuilder.ComposeFightUnits(opponentParty);
            TurnsManager.InitStates(FirstPartyTurns, SecondPartyTurns, mainParty.Units, opponentParty.Units);
            TurnsManager.Begin();
        }

#if DEBUG
        [Header("DEBUG")]
        public Party playerParty;
        public Party opponentParty;

        [ContextMenu("Debug Start Battle")]
        public void DebugStartBattle()
        {
            Begin(playerParty, opponentParty);
        }
#endif
    }
}