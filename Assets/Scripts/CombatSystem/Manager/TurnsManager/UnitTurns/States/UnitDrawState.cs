namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class UnitDrawState : State
    {
        public StateMachine RelatedStateMachine { get; private set; }

        public UnitDrawState(string name, StateMachine relatedStateMachine) : base(name) // I will pass here the "cards drawer".
        {
            RelatedStateMachine = relatedStateMachine;
        }

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