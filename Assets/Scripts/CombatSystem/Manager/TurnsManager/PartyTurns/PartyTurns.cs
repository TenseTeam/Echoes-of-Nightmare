namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using UnityEngine;

    public class PartyTurns : TurnStateMachine
    {
        public TurnStateMachine ParentStateMachine { get; private set; }
        private List<Unit> _combatants;

        public void InitStates(List<Unit> combatants, TurnStateMachine parentStateMachine)
        {
            _combatants = combatants;
            ParentStateMachine = parentStateMachine;
            InitStates();
        }

        protected override void InitStates()
        {
            base.InitStates();
            States.Add(null);
            foreach (Unit comb in _combatants)
            {
                States.Add(new PartyTurnState(comb.CombatantData.combatantName, this, comb));
            }
            States.Add(new EndSubStateMachine("EndPartyPhase", this));
        }
    }
}