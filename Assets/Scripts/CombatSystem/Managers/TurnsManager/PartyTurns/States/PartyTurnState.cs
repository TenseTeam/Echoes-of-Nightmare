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
#if DEBUG
            Debug.Log($"---ENTERING SUB STATEMACHINE OF {RelatedUnitManager.UnitData.UnitName} Unit.");
#endif
            if (!RelatedUnitManager.Unit.IsAlive)
            {
#if DEBUG
                Debug.Log($"--- {RelatedUnitManager.UnitData.UnitName} IS DEAD.");
#endif
                RelatedStateMachine.RemoveState(this);
                RelatedStateMachine.NextState(); // Do not confuse this with UnitTurns.NextState()
                return;
            }

            RelatedUnitManager.UnitTurns.Begin(); // Do not confuse Begin with NextState
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
