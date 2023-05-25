namespace ProjectEON.CombatSystem.StateMachines
{
    using System;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using UnityEngine;
    using UnityEngine.Rendering.PostProcessing;

    public class CombatTurns : TurnStateMachine
    {
        [SerializeField, Range(0, 100)]
        private sbyte _playerChanceToBegin = 50;

        public void InitStates(
            PlayerPartyTurns playerPartyTurns, EnemyPartyTurns enemyPartyTurns,
            PlayerParty playerParty, EnemyParty enemyParty,
            Action onPlayerWin, Action onEnemyWin)
        {
            base.InitStates();

            State combatTurnPlayerParty = new CombatTurnState<PlayerParty, PlayerPartyTurns>("PlayerPartyTurn", this, playerParty, playerPartyTurns);
            State combatTurnEnemyParty = new CombatTurnState<EnemyParty, EnemyPartyTurns>("EnemyPartyTurn", this, enemyParty, enemyPartyTurns);

            if (_playerChanceToBegin >= UnityEngine.Random.Range(0, 101)) 
            {
                States.Add(combatTurnPlayerParty);
                States.Add(combatTurnEnemyParty);
            }
            else
            {
                States.Add(combatTurnEnemyParty);
                States.Add(combatTurnPlayerParty);
            }

            States.Add(new CheckFightConditionCombatTurnState("CheckFightCondition", this, playerParty, enemyParty, onPlayerWin, onEnemyWin));
        }
    }
}