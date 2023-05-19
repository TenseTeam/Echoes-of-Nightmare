namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;

    public class EnemyUnitTurns : UnitTurns
    {
        public void InitStates(TurnStateMachine parentStateMachine, EnemyUnitManager unitManager)
        {
            base.InitStates(parentStateMachine);
            States.Add(new EnemyUnitActionState("EnemyAttackState", this, unitManager));
            States.Add(new EndSubStateMachine("EndEnemyUnitPhase", this, parentStateMachine));
        }
    }
}
