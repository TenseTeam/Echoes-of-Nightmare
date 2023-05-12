namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class CombatTurns : TurnStateMachine
    {
        private PlayerPartyTurns _playerPartySM;
        private EnemyPartyTurns _enemyPartySM;
        private List<Unit> _combatantsOne, _combatantsTwo;

        public void InitStates(
            PlayerPartyTurns playerPartyTurns, EnemyPartyTurns enemyPartyTurns,
            List<Unit> partyCombatantsOne, List<Unit> partyCombatantsTwo)
        {
            _playerPartySM = playerPartyTurns;
            _enemyPartySM = enemyPartyTurns;

            _combatantsOne = partyCombatantsOne;
            _combatantsTwo = partyCombatantsTwo;

            InitStates();
        }

        protected override void InitStates()
        {
            base.InitStates();
            States.Add(new PlayerCombatTurnState("PlayerPartyState", this, _playerPartySM, _combatantsOne));
            States.Add(new EnemyCombatTurnState("EnemyPartyState", this, _enemyPartySM, _combatantsTwo));
            // TO DO -> Maybe add here a state check for victory or loss.
        }
    }
}