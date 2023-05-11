namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class EndSubStateMachine : State
    {
        public TurnStateMachine ParentStateMachine { get; private set; }

        public EndSubStateMachine(string name, TurnStateMachine parentStateMachine) : base(name) // I will pass here the "cards drawer".
        {
            ParentStateMachine = parentStateMachine;
        }

        public override void Enter()
        {
            Debug.Log($"!!!ENTERING THE END SUBSTATE MACHINE OF {ParentStateMachine.transform.name}");
            ParentStateMachine.NextState();
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}