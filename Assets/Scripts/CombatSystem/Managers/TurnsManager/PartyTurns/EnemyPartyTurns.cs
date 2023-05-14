namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using UnityEngine;

    public class EnemyPartyTurns : SubTurnStateMachine
    {
        private EnemyParty _enemyParty;

        public void InitStates(EnemyParty enemyParty, TurnStateMachine parentStateMachine)
        {
            base.InitStates(parentStateMachine);
            _enemyParty = enemyParty;

            foreach (Unit unit in enemyParty.GetComposedUnits())
            {
                States.Add(new EnemyPartyTurnState(unit.Data.UnitName, this, unit));
            }
            States.Add(new EndSubStateMachine("EndEnemyPartyPhase", parentStateMachine));
        }
    }
}