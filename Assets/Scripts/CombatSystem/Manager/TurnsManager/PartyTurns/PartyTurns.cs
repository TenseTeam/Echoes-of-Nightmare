namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using UnityEngine;

    public class PartyTurns : SubTurnStateMachine
    {
        private List<Unit> _combatants;

        public void InitStates(List<Unit> combatants, TurnStateMachine parentStateMachine)
        {
            base.InitStates(parentStateMachine);
            _combatants = combatants;

            foreach (Unit comb in _combatants)
            {
                States.Add(new PartyTurnState(comb.Data.unitName, this, comb));
            }
            States.Add(new EndSubStateMachine("EndPartyPhase", parentStateMachine));
        }
    }
}