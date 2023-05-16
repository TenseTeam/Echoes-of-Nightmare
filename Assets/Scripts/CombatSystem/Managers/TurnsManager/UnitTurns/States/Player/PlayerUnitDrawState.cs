namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class PlayerUnitDrawState : UnitState<PlayerUnitManager>
    {
        public PlayerUnitDrawState(string name, TurnStateMachine relatedStateMachine, PlayerUnitManager unit) : base(name, relatedStateMachine, unit) // I will pass here the "cards drawer".
        {
        }

        public override void Enter()
        {
            Debug.Log($"----ENTERING DRAW STATE OF PLAYER'S UNIT {UnitManager.UnitData.UnitName}");
            Debug.Log("1 second before going next state.");
            UnitManager.UnitHand.SetActiveHand(true);
            RelatedStateMachine.NextStateIn(1f);
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}