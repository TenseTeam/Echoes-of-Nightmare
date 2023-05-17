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
        //private PlayerPartyTurns _playerPartySM;
        //private EnemyPartyTurns _enemyPartySM;

        public void InitStates(
            PlayerPartyTurns playerPartyTurns, EnemyPartyTurns enemyPartyTurns,
            PlayerParty playerParty, EnemyParty enemyParty,
            Action onPlayerWin, Action onEnemyWin)
        {
            //base.InitStates(); No need to call the base one in this case.
            States.Add(new PlayerCombatTurnState("PlayerPartyState", this, playerPartyTurns, playerParty));
            States.Add(new EnemyCombatTurnState("EnemyPartyState", this, enemyPartyTurns, enemyParty));
            States.Add(new CheckFightConditionCombatTurnState("CheckFightCondition", this, playerParty, enemyParty, onPlayerWin, onEnemyWin));
        }
    }
}