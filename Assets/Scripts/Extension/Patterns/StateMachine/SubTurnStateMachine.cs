namespace Extension.Patterns.StateMachine
{
    using System.Collections.Generic;
    using UnityEngine;

    public class SubTurnStateMachine : TurnStateMachine
    {
        public TurnStateMachine ParentStateMachine { get; private set; }

        protected void InitStates(TurnStateMachine parentStateMachine)
        {
            ParentStateMachine = parentStateMachine;
            InitStates();
        }
    }
}