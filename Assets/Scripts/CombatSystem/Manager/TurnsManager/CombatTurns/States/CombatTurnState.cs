namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.PartySystem;
    using UnityEngine;

    public class CombatTurnState : State
    {
        public TurnStateMachine RelatedStateMachine { get; private set; }
        private PartyTurns _partyTurns;

        public CombatTurnState(string name, TurnStateMachine relatedStateMachine, PartyTurns partyTurns, List<Unit> combatants) : base(name)
        {
            _partyTurns = partyTurns;
            RelatedStateMachine = relatedStateMachine;
            _partyTurns.InitStates(combatants, relatedStateMachine);
        }

        public override void Enter()
        {
            _partyTurns.NextState();
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}
