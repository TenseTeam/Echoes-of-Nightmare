namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class UnitAttackState : State
    {
        public TurnStateMachine RelatedStateMachine { get; private set; }

        private Unit _unit;

        public UnitAttackState(string name, Unit unit, TurnStateMachine relatedStateMachine) : base(name) // I will pass here the "cards drawer".
        {
            RelatedStateMachine = relatedStateMachine;
            _unit = unit;
        }

        //What it does on attack? When attack ended use: releatedStateMachine.NextState();

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}