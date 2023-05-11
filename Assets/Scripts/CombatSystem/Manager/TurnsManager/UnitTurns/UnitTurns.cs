namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using System.Collections.Generic;
    using UnityEngine;

    public class UnitTurns : SubTurnStateMachine
    {
        public void InitStates(TurnStateMachine parentStateMachine, Unit unit)
        {
            base.InitStates(parentStateMachine);
            //States.Add(new UnitDrawState("DrawPhase", this, unit));
            States.Add(new UnitAttackState("AttackPhase", this, unit));
            States.Add(new EndSubStateMachine("EndUnitPhase", parentStateMachine));
        }

        public void Begin()
        {
            ChangeState(0);
        }
    }
}
