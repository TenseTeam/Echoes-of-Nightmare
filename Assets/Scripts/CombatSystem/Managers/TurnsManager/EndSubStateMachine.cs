namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class EndSubStateMachine : LinkedState
    {
        public TurnStateMachine ParentStateMachine { get; private set; }

        public EndSubStateMachine(string name, TurnStateMachine relatedStateMachine, TurnStateMachine parentStateMachine) : base(name, parentStateMachine)
        {
            ParentStateMachine = parentStateMachine;
        }

        public override void Enter()
        {
            ParentStateMachine.NextState();
            //RelatedStateMachine.SetCurrentKey(0);
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}