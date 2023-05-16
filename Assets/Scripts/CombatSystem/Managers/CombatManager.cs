namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.CombatSystem.PartyComposers;
    using ProjectEON.PartySystem;

    public class CombatManager : Singleton<CombatManager>
    {
        [field: SerializeField, Header("Managers")]
        public AttacksManager AttacksManager { get; private set; }
        [field: SerializeField]
        public TargetManager TargetManager { get; private set; }
        [field: SerializeField]
        public UICombatManager UICombatManager { get; private set; }

        [field: SerializeField, Header("Player Party")]
        public PlayerParty PlayerParty { get; private set; }

        [field: SerializeField, Header("Party Builders")]
        public PlayerPartyBattleComposer PlayerPartyComposer { get; private set; }
        [field: SerializeField]
        public EnemyPartyBattleComposer EnemyPartyComposer { get; private set; }

        [field: SerializeField, Header("Combat Turns Manager")]
        public CombatTurns TurnsManager { get; private set; }

        [field: SerializeField, Header("PartyTurns")]
        public PlayerPartyTurns PlayerPartyTurns { get; private set; }
        [field: SerializeField]
        public EnemyPartyTurns EnemyPartyTurns { get; private set; }

        public void BeginBattle(EnemyParty enemyParty)
        {
            BuildEnemyParty(enemyParty);
            TurnsManager.InitStates(PlayerPartyTurns, EnemyPartyTurns, PlayerParty, enemyParty);
            TurnsManager.Begin();
        }

        public void BuildPlayerParty()
        {
            PlayerPartyComposer.ComposeUnits(PlayerParty);
        }

        private void BuildEnemyParty(Party enemyParty)
        {
            EnemyPartyComposer.InFightUnitsManager.Clear();
            EnemyPartyComposer.ComposeUnits(enemyParty);
        }

#if DEBUG
        [Header("DEBUG")]
        public EnemyParty opponentParty;

        [ContextMenu("Debug Start Battle")]
        public void DebugStartBattle()
        {
            BeginBattle(opponentParty);
        }

        [ContextMenu("Build Player Party")]
        public void DebugBuildParty()
        {
            BuildPlayerParty();
        }
#endif
    }
}