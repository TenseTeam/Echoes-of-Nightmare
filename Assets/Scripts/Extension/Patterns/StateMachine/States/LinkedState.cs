namespace Extension.Patterns.StateMachine
{
    using Extension.Patterns.StateMachine.Interfaces;

    public abstract class LinkedState : IEventState
    {
        public string StateName { get; private set; }
        public StateMachine RelatedStateMachine { get; private set; }

        /// <summary>
        /// Initializes a new instance of the State class with the specified name.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        protected LinkedState(string name, StateMachine relatedStateMachine)
        {
            StateName = name;
            RelatedStateMachine = relatedStateMachine;
        }

        /// <inheritdoc/>
        public abstract void Enter();

        /// <inheritdoc/>
        public abstract void Exit();

        /// <inheritdoc/>
        public abstract void Process();
    }
}