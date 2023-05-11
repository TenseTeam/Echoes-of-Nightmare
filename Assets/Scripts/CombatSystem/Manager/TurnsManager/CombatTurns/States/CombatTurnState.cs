namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.PartySystem;
    using UnityEngine;

    public class CombatTurnState : LinkedTurnState
    {
        private PartyTurns _partyTurns;

        public CombatTurnState(string name, TurnStateMachine relatedStateMachine, PartyTurns partyTurns, List<Unit> combatants) : base(name, relatedStateMachine)
        {
            _partyTurns = partyTurns;
            _partyTurns.InitStates(combatants, relatedStateMachine);
        }

        public override void Enter()
        {
            Debug.Log($"--ENTERING STATEMACHINE OF {_partyTurns.transform.name}");
            _partyTurns.Begin();
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}
