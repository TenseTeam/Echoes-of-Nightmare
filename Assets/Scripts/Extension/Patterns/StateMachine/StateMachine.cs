namespace Extension.Patterns.StateMachine
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class StateMachine : MonoBehaviour
    {
        public State CurrentState { get; private set; }

        public int CurrentStateKey { get; protected set; } = 0;

        protected List<State> States { get; set; } = new List<State>();

        /// <summary>
        /// Initializes the states list.
        /// </summary>
        protected virtual void InitStates() { }

        protected virtual void Start()
        {
            CurrentState?.Enter();
        }

        protected virtual void Update()
        {
            CurrentState?.Process();
        }

        /// <summary>
        /// Changes the state to a given one.
        /// </summary>
        /// <param name="stateKey">Integer key of the target state.</param>
        public void ChangeState(int stateKey)
        {
            if (States[stateKey] != CurrentState)
            {
                CurrentState?.Exit();
                CurrentStateKey = stateKey;
                CurrentState = States[stateKey];
                CurrentState?.Enter();
            }
        }

        /// <summary>
        /// Begins the state machine starting from the state of index 0.
        /// </summary>
        public virtual void Begin()
        {
            ChangeState(0);
        }
    }
}