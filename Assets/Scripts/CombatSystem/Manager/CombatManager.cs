namespace ProjectEON.CombatSystem.Manager
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.PartySystem;

    public class CombatManager : Singleton<CombatManager>
    {
        [field: SerializeField, Header("UI (TO CHANGE WITH THE UI MANAGER)")]
        public RectTransform UICanvas { get; private set; }  // This is temporary, a UI manager is needed.

        [field: SerializeField, Header("Pools")]
        public UnitsPool PlayerUnitsPool { get; private set; }
        [field: SerializeField]
        public UnitsPool UnitsPool { get; private set; }

        [field: SerializeField, Header("Party Builders")]
        public CombatPartyComposer PlayerPartyBuilder { get; private set; }
        [field: SerializeField]
        public CombatPartyComposer EnemyPartyBuilder { get; private set; }

        [field: SerializeField, Header("Combat Turns Manager")]
        public CombatTurns TurnsManager { get; private set; }

        [field: SerializeField, Header("PartyTurns")]
        public PlayerPartyTurns PlayerPartyTurns { get; private set; }
        [field: SerializeField]
        public EnemyPartyTurns EnemyPartyTurns { get; private set; }

        public void Begin(Party mainParty, Party opponentParty)
        {
            opponentParty.BuildParty();
            PlayerPartyBuilder.ComposeFightUnits(mainParty);
            EnemyPartyBuilder.ComposeFightUnits(opponentParty);
            TurnsManager.InitStates(PlayerPartyTurns, EnemyPartyTurns, mainParty.Units, opponentParty.Units);
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

        [ContextMenu("Debug Force Next State")]
        public void ForceNextState()
        {
            TurnsManager.NextState();
        }
#endif
    }
}