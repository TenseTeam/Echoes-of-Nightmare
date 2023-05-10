namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class CombatTurns : TurnStateMachine
    {
        private PartyTurns _firstPartyStateMachine, _secondPartyStateMachine;
        private List<Unit> _combatantsOne, _combatantsTwo;

        protected override void Awake() // Do not initialize the states before the parties are assigned
        {
        }

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
            States.Add(null);
            States.Add(new CombatTurnState("FirstPartyState", this, _firstPartyStateMachine, _combatantsOne));
            States.Add(new CombatTurnState("SecondPartyState", this, _secondPartyStateMachine, _combatantsTwo));
        }

        /// <summary>
        /// Begins the Combat Turns State Machine.
        /// </summary>
        public void Begin()
        {
            NextState();
        }
    }
}