namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class CombatTurns : TurnStateMachine
    {
        private PartyTurns _firstPartyStateMachine, _secondPartyStateMachine;
        private List<Unit> _combatantsOne, _combatantsTwo;

        public void InitStates(
            PartyTurns firstPartyStateMachine, PartyTurns secondPartyStateMachine,
            List<Unit> partyCombatantsOne, List<Unit> partyCombatantsTwo)
        {
            _firstPartyStateMachine = firstPartyStateMachine;
            _secondPartyStateMachine = secondPartyStateMachine;

            _combatantsOne = partyCombatantsOne;
            _combatantsTwo = partyCombatantsTwo;

            InitStates();
        }

        protected override void InitStates()
        {
            base.InitStates();
            States.Add(new CombatTurnState("FirstPartyState", this, _firstPartyStateMachine, _combatantsOne));
            States.Add(new CombatTurnState("SecondPartyState", this, _secondPartyStateMachine, _combatantsTwo));
        }
    }
}