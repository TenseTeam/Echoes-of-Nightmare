namespace ProjectEON.CombatSystem.StateMachines
{
    using System;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using UnityEngine;

    public class CombatTurns : TurnStateMachine
    {
        public void InitStates(
            PlayerPartyTurns playerPartyTurns, EnemyPartyTurns enemyPartyTurns,
            PlayerParty playerParty, EnemyParty enemyParty,
            Action onPlayerWin, Action onEnemyWin)
        {
            base.InitStates();
            States.Add(new CombatTurnState<PlayerParty, PlayerPartyTurns>("PlayerPartyTurn", this, playerParty, playerPartyTurns));
            States.Add(new CombatTurnState<EnemyParty, EnemyPartyTurns>("EnemyPartyTurn", this, enemyParty, enemyPartyTurns));
            States.Add(new CheckFightConditionCombatTurnState("CheckFightCondition", this, playerParty, enemyParty, onPlayerWin, onEnemyWin));
            //States.Add(new PlayerCombatTurnState("PlayerPartyState", this, playerPartyTurns, playerParty));
            //States.Add(new EnemyCombatTurnState("EnemyPartyState", this, enemyPartyTurns, enemyParty));
        }
    }
}