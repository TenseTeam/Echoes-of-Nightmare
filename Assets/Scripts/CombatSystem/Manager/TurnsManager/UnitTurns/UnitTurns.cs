namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;

    public class UnitTurns : SubTurnStateMachine
    {
        public void InitStates(TurnStateMachine parentStateMachine, Unit unit)
        {
            base.InitStates(parentStateMachine);
            States.Add(new UnitDrawState("DrawPhase", this, unit));
            States.Add(new UnitActionState("AttackPhase", this, unit));
            States.Add(new EndSubStateMachine("EndUnitPhase", parentStateMachine));
        }
    }
}
