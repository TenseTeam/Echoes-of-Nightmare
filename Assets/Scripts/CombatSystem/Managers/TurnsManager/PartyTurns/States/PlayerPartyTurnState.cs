namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;

    public class PlayerPartyTurnState : PartyTurnState
    {
        public PlayerPartyTurnState(string name, TurnStateMachine relatedStateMachine, Unit relatedCombatant) : base(name, relatedStateMachine, relatedCombatant)
        {
        }

        protected override void InitUnitTurnStates(Unit unit, TurnStateMachine relatedStateMachine)
        {
            if (RelatedUnit.TryGetComponent(out PlayerUnitTurns unitTurns))
            {
                UnitTurns = unitTurns;
                unitTurns.InitStates(relatedStateMachine, unit as PlayerUnit);
            }
        }
    }
}
