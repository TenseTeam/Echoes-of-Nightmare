namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class PlayerUnitCardSelectionState : UnitState<PlayerUnitManager>
    {
        public PlayerUnitCardSelectionState(string name, TurnStateMachine relatedStateMachine, PlayerUnitManager unit) : base(name, relatedStateMachine, unit) // I will pass here the "cards drawer".
        {
        }

        public override void Enter()
        {
#if DEBUG
            Debug.Log("---- PLAYER CARDS STATE");
#endif
            UnitManager.UnitHand.SetActiveHand(true);
        }

        public override void Exit()
        {
            UnitManager.UnitHand.SetActiveHand(false);
        }

        public override void Process()
        {
        }
    }
}