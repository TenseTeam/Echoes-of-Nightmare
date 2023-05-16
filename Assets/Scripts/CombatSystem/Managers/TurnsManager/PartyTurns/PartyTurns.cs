namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;

    public class PartyTurns<T> : SubTurnStateMachine where T : Party
    {
        protected T Party;

        public virtual void InitStates(T party, TurnStateMachine parentStateMachine)
        {
            InitStates(parentStateMachine);
            Party = party;
        }
    }
}