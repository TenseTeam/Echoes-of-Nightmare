namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using UnityEngine;

    public class PlayerPartyTurns : SubTurnStateMachine
    {
        private PlayerParty _playerParty;

        public void InitStates(PlayerParty playerParty, TurnStateMachine parentStateMachine)
        {
            base.InitStates(parentStateMachine);
            _playerParty = playerParty;

            foreach (PlayerUnit unit in _playerParty.GetComposedUnits())
            {
                States.Add(new PlayerPartyTurnState(unit.Data.UnitName, this, unit));
            }
            States.Add(new EndSubStateMachine("EndPlayerPartyPhase", parentStateMachine));
        }
    }
}