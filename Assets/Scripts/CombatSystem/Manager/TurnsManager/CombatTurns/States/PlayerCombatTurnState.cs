namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class PlayerCombatTurnState : LinkedTurnState
    {
        private PlayerPartyTurns _partyTurns;

        public PlayerCombatTurnState(string name, TurnStateMachine relatedStateMachine, PlayerPartyTurns partyTurns, List<Unit> combatants) : base(name, relatedStateMachine)
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
