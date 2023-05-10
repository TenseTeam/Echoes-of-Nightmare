namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using System.Collections.Generic;
    using UnityEngine;

    public class UnitTurns : TurnStateMachine
    {
        public TurnStateMachine ParentStateMachine { get; private set; }

        public void InitStates(TurnStateMachine parentStateMachine, Unit unit)
        {
            ParentStateMachine = parentStateMachine;
            States.Add(null);
            States.Add(new UnitDrawState("DrawPhase", this));
            States.Add(new UnitAttackState("AttackPhase", unit, this));
            States.Add(new EndSubStateMachine("EndUnitPhase", parentStateMachine));
            InitStates();
        }
    }
}
