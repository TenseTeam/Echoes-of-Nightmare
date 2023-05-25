namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.CombatSystem.PartyComposers;
    using ProjectEON.PartySystem;
    using System;

    public class CombatManager : MonoBehaviour /*Singleton<CombatManager>*/
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

        public event Action OnPlayerEndFight;
        public event Action OnEnemyWin;
        public event Action OnFightBegin;

        /// <summary>
        /// Initializes the Combat Manager with the relatives Actions.
        /// </summary>
        /// <param name="onFightBegin">Event On Fight Begin.</param>
        /// <param name="onEndFight">Event On End Fight.</param>
        /// <param name="onEnemyWin">Event On Enemy Party Win.</param>
        public void Init(Action onFightBegin, Action onEndFight, Action onEnemyWin)
        {
            OnFightBegin = onFightBegin;
            OnPlayerEndFight = onEndFight;
            OnEnemyWin = onEnemyWin;
        }

        /// <summary>
        /// Begins the battle with an enemy party.
        /// </summary>
        /// <param name="enemyParty">EnemyParty.</param>
        public void BeginBattle(EnemyParty enemyParty)
        {
            BuildEnemyParty(enemyParty);
            TurnsManager.InitStates(PlayerPartyTurns, EnemyPartyTurns, PlayerParty, enemyParty, OnPlayerEndFight, OnEnemyWin);
            TurnsManager.Begin();
            OnFightBegin?.Invoke();
        }

        /// <summary>
        /// Composes the player party in the battle.
        /// </summary>
        public void BuildPlayerParty()
        {
            PlayerPartyComposer.ComposeUnits(PlayerParty);
        }

        /// <summary>
        /// Composes an enemy party in the battle.
        /// </summary>
        /// <param name="enemyParty">EnemyParty.</param>
        private void BuildEnemyParty(Party enemyParty)
        {
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
#endif
    }
}