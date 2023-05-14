namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using UnityEngine;

    public class CombatTurns : TurnStateMachine
    {
        private PlayerPartyTurns _playerPartySM;
        private EnemyPartyTurns _enemyPartySM;

        public void InitStates(
            PlayerPartyTurns playerPartyTurns, EnemyPartyTurns enemyPartyTurns,
            PlayerParty playerParty, EnemyParty enemyParty)
        {
            _playerPartySM = playerPartyTurns;
            _enemyPartySM = enemyPartyTurns;

            InitStates(playerParty, enemyParty);
        }

        protected void InitStates(PlayerParty playerParty, EnemyParty enemyParty)
        {
            base.InitStates();
            States.Add(new PlayerCombatTurnState("PlayerPartyState", this, _playerPartySM, playerParty));
            States.Add(new EnemyCombatTurnState("EnemyPartyState", this, _enemyPartySM, enemyParty));
            // TO DO -> Maybe add here a state check for victory or loss.
        }
    }
}