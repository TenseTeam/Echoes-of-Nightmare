namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class PlayerUnitActionState : LinkedTurnState
    {
        private PlayerUnit _unit;

        public PlayerUnitActionState(string name, TurnStateMachine relatedStateMachine, PlayerUnit unit) : base(name, relatedStateMachine) // I will pass here the "cards drawer".
        {
            _unit = unit;
        }

        //What it does on attack? When attack ended use: releatedStateMachine.NextState();

        public override void Enter()
        {
            Debug.Log($"----ENTERING ATTACK STATE OF PLAYER'S UNIT {_unit.Data.unitName} OF PARTY");
            Debug.Log("Press 1 to go next state.");
        }

        public override void Exit()
        {
            _unit.UnitHand.SetActiveHand(false);
        }

        public override void Process()
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
                RelatedStateMachine.NextState();
        }
    }
}