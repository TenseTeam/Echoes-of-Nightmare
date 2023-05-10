namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using Extension.Patterns.Singleton;
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class PartyTurnState : State
    {
        public TurnStateMachine RelatedStateMachine { get; private set; }
        private Unit _releatedCombatant;
        private UnitTurns _unitTurns;

        public PartyTurnState(string name, TurnStateMachine relatedStateMachine, Unit releatedCombatant) : base(name)
        {
            RelatedStateMachine = relatedStateMachine;
            _releatedCombatant = releatedCombatant;

            if(releatedCombatant.TryGetComponent(out UnitTurns unitTurns))
            {
                _unitTurns = unitTurns;
                _unitTurns.InitStates(relatedStateMachine, releatedCombatant);
            }
        }

        public override void Enter()
        {
            _unitTurns.NextState();
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}
