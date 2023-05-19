namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using System.Collections.Generic;
    using UnityEngine;

    public class PartyTurns<T> : SubTurnStateMachine where T : Party
    {
        protected T Party;

        public virtual void InitStates(T party, TurnStateMachine parentStateMachine)
        {
            Party = party;
            InitStates(parentStateMachine);
        }

#if DEBUG
        [ContextMenu("Next State")]
        private void DebugNextState()
        {
            NextState();
        }
#endif
    }
}