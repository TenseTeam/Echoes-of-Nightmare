namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class EnemyPartyTurns : SubTurnStateMachine
    {
        private List<Unit> _units;

        public void InitStates(List<Unit> units, TurnStateMachine parentStateMachine)
        {
            base.InitStates(parentStateMachine);
            _units = units;

            foreach (Unit unit in _units)
            {
                States.Add(new EnemyPartyTurnState(unit.Data.unitName, this, unit));
            }
            States.Add(new EndSubStateMachine("EndEnemyPartyPhase", parentStateMachine));
        }
    }
}