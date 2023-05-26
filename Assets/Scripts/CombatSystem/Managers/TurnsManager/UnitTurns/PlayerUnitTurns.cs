namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;

    public class PlayerUnitTurns : UnitTurns
    {
        public void InitStates(TurnStateMachine parentStateMachine, PlayerUnitManager playerUnit)
        {
            base.InitStates(parentStateMachine);
            States.Add(new PlayerUnitCardSelectionState("PlayerSelectionPhase", this, playerUnit));
            States.Add(new PlayerUnitActionState("PlayerActionPhase", this, playerUnit));
            States.Add(new EndSubStateMachine("EndPlayerUnitPhase", this, parentStateMachine));
        }
    }
}
