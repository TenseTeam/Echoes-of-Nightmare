namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;

    public class EnemyPartyTurnState : PartyTurnState
    {
        public EnemyPartyTurnState(string name, TurnStateMachine relatedStateMachine, UnitManager relatedUnitManager) : base(name, relatedStateMachine, relatedUnitManager)
        {
        }
    }
}
