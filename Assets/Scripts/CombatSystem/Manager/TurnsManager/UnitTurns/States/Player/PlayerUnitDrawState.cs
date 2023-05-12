namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class PlayerUnitDrawState : LinkedTurnState
    {
        private PlayerUnit _unit;

        public PlayerUnitDrawState(string name, TurnStateMachine relatedStateMachine, PlayerUnit unit) : base(name, relatedStateMachine) // I will pass here the "cards drawer".
        {
            _unit = unit;
        }

        public override void Enter()
        {
            Debug.Log($"----ENTERING DRAW STATE OF PLAYER'S UNIT {_unit.Data.unitName}");
            Debug.Log("1 second before going next state.");
            _unit.UnitHand.SetActiveHand(true);
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