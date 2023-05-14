namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;

    public class PlayerUnitTurns : UnitTurns
    {
        public void InitStates(TurnStateMachine parentStateMachine, PlayerUnit playerUnit)
        {
            base.InitStates(parentStateMachine);
            States.Add(new PlayerUnitDrawState("PlayerDrawPhase", this, playerUnit));
            States.Add(new PlayerUnitActionState("PlayerAttackPhase", this, playerUnit));
            States.Add(new EndSubStateMachine("EndPlayerUnitPhase", parentStateMachine));
        }
    }
}
