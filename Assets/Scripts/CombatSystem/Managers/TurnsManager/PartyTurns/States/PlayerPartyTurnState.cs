namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;

    public class PlayerPartyTurnState : PartyTurnState
    {
        public PlayerPartyTurnState(string name, TurnStateMachine relatedStateMachine, UnitManager relatedUnitManager) : base(name, relatedStateMachine, relatedUnitManager)
        {
        }

        protected override void InitUnitTurnStates(UnitManager unit, TurnStateMachine relatedStateMachine)
        {
            unit.UnitTurns.InitStates(relatedStateMachine);
        }
    }
}
