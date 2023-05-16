namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class EnemyUnitActionState : UnitState<UnitManager>
    {
        public EnemyUnitActionState(string name, TurnStateMachine relatedStateMachine, UnitManager unit) : base(name, relatedStateMachine, unit) // I will pass here the "cards drawer".
        {
        }

        //What it does on attack?
        public override void Enter()
        {
            Debug.Log($"----ENTERING ATTACK STATE OF ENEMY'S UNIT {UnitManager.UnitData.UnitName} OF PARTY");
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