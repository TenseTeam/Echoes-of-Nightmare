namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class EnemyUnitActionState : LinkedTurnState
    {
        private Unit _unit;

        public EnemyUnitActionState(string name, TurnStateMachine relatedStateMachine, Unit unit) : base(name, relatedStateMachine) // I will pass here the "cards drawer".
        {
            _unit = unit;
        }

        //What it does on attack?

        public override void Enter()
        {
            Debug.Log($"----ENTERING ATTACK STATE OF ENEMY'S UNIT {_unit.Data.unitName} OF PARTY");
            Debug.Log("Waiting 2 seconds before next state.");
            RelatedStateMachine.NextStateIn(2f);
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}