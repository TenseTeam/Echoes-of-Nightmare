namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class UnitAttackState : LinkedTurnState
    {
        private Unit _unit;

        public UnitAttackState(string name, TurnStateMachine relatedStateMachine, Unit unit) : base(name, relatedStateMachine) // I will pass here the "cards drawer".
        {
            _unit = unit;
        }

        //What it does on attack? When attack ended use: releatedStateMachine.NextState();

        public override void Enter()
        {
            Debug.Log($"----ENTERING ATTACK STATE OF {_unit.Data.unitName} OF PARTY");
            Debug.Log("Press 1 to go next state.");
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
                RelatedStateMachine.NextState();
        }
    }
}