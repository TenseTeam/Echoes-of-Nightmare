namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class EnemyUnitActionState : UnitState<EnemyUnitManager>
    {
        public EnemyUnitActionState(string name, TurnStateMachine relatedStateMachine, EnemyUnitManager unit) : base(name, relatedStateMachine, unit) // I will pass here the "cards drawer".
        {
        }

        public override void Enter()
        {
#if DEBUG
            Debug.Log("---- TRYING TO ATTACK A TARGET!");
#endif
            UnitManager.EnemyAI.AttackRandomTarget();
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