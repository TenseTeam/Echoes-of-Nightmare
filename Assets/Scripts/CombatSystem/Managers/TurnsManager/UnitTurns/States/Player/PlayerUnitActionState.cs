namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class PlayerUnitActionState : UnitState<PlayerUnitManager>
    {
        public PlayerUnitActionState(string name, TurnStateMachine relatedStateMachine, PlayerUnitManager unit) : base(name, relatedStateMachine, unit) // I will pass here the "cards drawer".
        {
        }

        public override void Enter()
        {
            Debug.Log($"----ENTERING ATTACK STATE OF PLAYER'S UNIT {UnitManager.UnitData.UnitName} OF PARTY");
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