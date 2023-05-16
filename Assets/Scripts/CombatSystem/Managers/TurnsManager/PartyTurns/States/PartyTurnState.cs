namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class PartyTurnState : LinkedTurnState
    {
        protected UnitManager RelatedUnitManager;
        
        public PartyTurnState(string name, TurnStateMachine relatedStateMachine, UnitManager relatedUnit) : base(name, relatedStateMachine)
        {
            RelatedUnitManager = relatedUnit;
            //(RelatedUnitManager.UnitTurns as T).InitStates(relatedStateMachine, relatedUnit);
        }

        public override void Enter()
        {
            Debug.Log($"---ENTERING SUB STATEMACHINE OF {RelatedUnitManager.UnitData.UnitName} Unit.");

            Debug.LogError($"States count: {RelatedUnitManager.UnitTurns}");

            if (!RelatedUnitManager.Unit.IsAlive)
            {
                Debug.Log("--- IS DEAD.");
                RelatedStateMachine.NextState();
                return;
            }

            RelatedUnitManager.UnitTurns.Begin(); // ERROR
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }

        //protected virtual void InitUnitTurnStates(UnitManager unit, TurnStateMachine relatedStateMachine)
        //{
        //    unit.UnitTurns.InitStates(relatedStateMachine);

        //    //if (RelatedUnit.TryGetComponent(out UnitTurns unitTurns))
        //    //{
        //    //    UnitTurns = unitTurns;
        //    //    UnitTurns.InitStates(relatedStateMachine, RelatedUnit);
        //    //}
        //}
    }
}
