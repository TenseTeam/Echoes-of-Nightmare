namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using UnityEngine;

    public class PlayerCombatTurnState : LinkedTurnState
    {
        private PlayerPartyTurns _partyTurns;
        private PlayerParty _party;

        public PlayerCombatTurnState(string name, TurnStateMachine relatedStateMachine, PlayerPartyTurns partyTurns, PlayerParty playerParty) : base(name, relatedStateMachine)
        {
            _party = playerParty;
            _partyTurns = partyTurns;
            _partyTurns.InitStates(playerParty, relatedStateMachine);
        }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"--ENTERING STATEMACHINE OF {_partyTurns.transform.name}");
#endif
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
