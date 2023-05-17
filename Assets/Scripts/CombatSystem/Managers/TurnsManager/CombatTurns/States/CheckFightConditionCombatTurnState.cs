namespace ProjectEON.CombatSystem.StateMachines
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using UnityEngine;

    public class CheckFightConditionCombatTurnState : LinkedTurnState
    {
        private PlayerParty _playerParty;
        private EnemyParty _enemyParty;

        private event Action _onPlayerPartyWin;
        private event Action _onEnemyPartyWin;

        public CheckFightConditionCombatTurnState(
            string name,
            TurnStateMachine relatedStateMachine,
            PlayerParty playerParty,
            EnemyParty enemyParty,
            Action onPlayerPartyWin,
            Action onEnemyPartyWin) : base(name, relatedStateMachine)
        {
            _playerParty = playerParty;
            _enemyParty = enemyParty;
            _onPlayerPartyWin = onPlayerPartyWin;
            _onEnemyPartyWin = onEnemyPartyWin;
        }

        public override void Enter()
        {
            if(!_playerParty.AreThereMembersAlive()) // Check first if the enemies have won.
            {
#if DEBUG
                Debug.Log("ENEMY PARTY HAVE WON");
#endif
                _onEnemyPartyWin.Invoke(); // Doesnt use the null pattern (?) because I want to force the implementation of the events.
                return;
            }

            if (!_enemyParty.AreThereMembersAlive())
            {
#if DEBUG
                Debug.Log("PLAYER PARTY HAVE WON");
#endif
                _onPlayerPartyWin.Invoke();
                return;
            }

            RelatedStateMachine.NextState();
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}