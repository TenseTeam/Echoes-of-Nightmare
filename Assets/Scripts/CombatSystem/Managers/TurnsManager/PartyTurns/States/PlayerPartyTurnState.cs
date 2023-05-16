namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;

    public class PlayerPartyTurnState : PartyTurnState
    {
        public PlayerPartyTurnState(string name, TurnStateMachine relatedStateMachine, PlayerUnitManager relatedUnitManager) : base(name, relatedStateMachine, relatedUnitManager)
        {
            (relatedUnitManager.UnitTurns as PlayerUnitTurns).InitStates(relatedStateMachine, relatedUnitManager);
        }
    }
}
