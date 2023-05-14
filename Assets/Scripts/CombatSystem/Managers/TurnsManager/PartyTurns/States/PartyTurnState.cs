namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class PartyTurnState : LinkedTurnState
    {
        protected Unit RelatedUnit;
        protected UnitTurns UnitTurns;

        public PartyTurnState(string name, TurnStateMachine relatedStateMachine, Unit relatedUnit) : base(name, relatedStateMachine)
        {
            RelatedUnit = relatedUnit;
            InitUnitTurnStates(relatedUnit, relatedStateMachine);
        }

        public override void Enter()
        {
            Debug.Log($"---ENTERING SUB STATEMACHINE OF {RelatedUnit.Data.UnitName} Unit.");

            if (!RelatedUnit.IsAlive)
            {
                Debug.Log("--- IS DEAD.");
                RelatedStateMachine.NextState();
                return;
            }

            UnitTurns.Begin();
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }

        protected virtual void InitUnitTurnStates(Unit unit, TurnStateMachine relatedStateMachine)
        {
            if (RelatedUnit.TryGetComponent(out UnitTurns unitTurns))
            {
                UnitTurns = unitTurns;
                UnitTurns.InitStates(relatedStateMachine, RelatedUnit);
            }
        }
    }
}
