namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;

    public class EnemyPartyTurnState : PartyTurnState
    {
        public EnemyPartyTurnState(string name, TurnStateMachine relatedStateMachine, Unit relatedCombatant) : base(name, relatedStateMachine, relatedCombatant)
        {
        }
    }
}
