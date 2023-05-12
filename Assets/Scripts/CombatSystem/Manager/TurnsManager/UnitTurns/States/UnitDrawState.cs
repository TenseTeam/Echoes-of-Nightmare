namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class UnitDrawState : LinkedTurnState
    {
        private Unit _unit;

        public UnitDrawState(string name, TurnStateMachine relatedStateMachine, Unit unit) : base(name, relatedStateMachine) // I will pass here the "cards drawer".
        {
            _unit = unit;
        }

        public override void Enter()
        {
            Debug.Log($"----ENTERING DRAW STATE OF {_unit.Data.unitName}");
            Debug.Log("Press TAB to go next state.");
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
                RelatedStateMachine.NextState();
        }
    }
}