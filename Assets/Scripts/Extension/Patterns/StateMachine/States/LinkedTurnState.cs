namespace Extension.Patterns.StateMachine
{
    using Extension.Patterns.StateMachine.Interfaces;

    public abstract class LinkedTurnState : IEventState
    {
        public string StateName { get; private set; }
        public TurnStateMachine RelatedStateMachine { get; private set; }

        /// <summary>
        /// Initializes a new instance of the State class with the specified name.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        protected LinkedTurnState(string name, TurnStateMachine relatedStateMachine)
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