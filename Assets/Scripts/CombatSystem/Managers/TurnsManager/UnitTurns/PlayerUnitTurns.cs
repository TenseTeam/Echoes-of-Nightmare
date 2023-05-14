namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;

    public class PlayerUnitTurns : SubTurnStateMachine
    {
        public void InitStates(TurnStateMachine parentStateMachine, PlayerUnit unit)
        {
            base.InitStates(parentStateMachine);
            States.Add(new PlayerUnitDrawState("PlayerDrawPhase", this, unit));
            States.Add(new PlayerUnitActionState("PlayerAttackPhase", this, unit));
            States.Add(new EndSubStateMachine("EndPlayerUnitPhase", parentStateMachine));
        }
    }
}
