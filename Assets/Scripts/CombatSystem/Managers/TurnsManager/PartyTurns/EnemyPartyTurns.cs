namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyPartyTurns : PartyTurns<EnemyParty>
    {
        public List<string> visibleState;

        public override void InitStates(EnemyParty enemyParty, TurnStateMachine parentStateMachine)
        {
            base.InitStates(enemyParty, parentStateMachine);

            visibleState = new List<string>();

            foreach (EnemyUnitManager unitManager in Party.GetComposedUnits())
            {
                State state = new EnemyPartyTurnState(unitManager.UnitData.UnitName, this, unitManager);
                States.Add(state);
                visibleState.Add(state.StateName);
            }
            States.Add(new EndSubStateMachine("EndEnemyPartyPhase", this, parentStateMachine));



        }
    }
}