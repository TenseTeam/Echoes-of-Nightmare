namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;

    public class EnemyPartyTurnState : PartyTurnState
    {
        public EnemyPartyTurnState(string name, TurnStateMachine relatedStateMachine, EnemyUnitManager relatedUnitManager) : base(name, relatedStateMachine, relatedUnitManager)
        {
            (relatedUnitManager.UnitTurns as EnemyUnitTurns).InitStates(relatedStateMachine, relatedUnitManager);
        }
    }
}
