namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;

    public class EnemyUnitTurns : SubTurnStateMachine
    {
        public void InitStates(TurnStateMachine parentStateMachine, Unit unit)
        {
            base.InitStates(parentStateMachine);
            States.Add(new EnemyUnitActionState("EnemyAttackState", this, unit));
            States.Add(new EndSubStateMachine("EndEnemyUnitPhase", parentStateMachine));
        }
    }
}
