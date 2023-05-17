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
        protected virtual void InitStates() { } // This is not abstract because I don't want to force the implementation of this method.

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
        /// Removes a state from the states list.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        public void RemoveState(int stateKey)
        {
            States.Remove(States[stateKey]);
        }

        /// <summary>
        /// Adds a state.
        /// </summary>
        /// <param name="state">State to add.</param>
        public void AddState(State state)
        {
            States.Add(state);
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