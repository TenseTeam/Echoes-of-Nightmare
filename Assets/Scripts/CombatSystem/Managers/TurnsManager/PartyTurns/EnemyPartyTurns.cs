namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyPartyTurns : PartyTurns<EnemyParty>
    {
        public override void InitStates(EnemyParty enemyParty, TurnStateMachine parentStateMachine)
        {
            base.InitStates(enemyParty, parentStateMachine);

            foreach (EnemyUnitManager unitManager in Party.GetComposedUnits())
            {
                States.Add(new EnemyPartyTurnState(unitManager.UnitData.UnitName, this, unitManager));
            }
            States.Add(new EndSubStateMachine("EndEnemyPartyPhase", this, parentStateMachine));
        }
    }
}