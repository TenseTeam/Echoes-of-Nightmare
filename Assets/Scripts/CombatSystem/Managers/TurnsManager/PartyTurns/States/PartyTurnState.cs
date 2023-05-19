namespace ProjectEON.CombatSystem.StateMachines
{
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;
    using UnityEngine;
    using static UnityEditor.VersionControl.Asset;

    public class PartyTurnState : LinkedTurnState
    {
        protected UnitManager RelatedUnitManager;
        
        public PartyTurnState(string name, TurnStateMachine relatedStateMachine, UnitManager relatedUnit) : base(name, relatedStateMachine)
        {
            RelatedUnitManager = relatedUnit;
        }

        public override void Enter()
        {
            RelatedUnitManager.UnitTurnStart();

            #region TO FIX CHECK UNIT STATUS PARTY
#if DEBUG
            Debug.Log($"---ENTERING SUB STATEMACHINE OF {RelatedUnitManager.UnitData.UnitName} Unit.");
#endif
            //RelatedUnitManager.UnitStatusEffects.ProcessStatusEffects();

            if (!RelatedUnitManager.Unit.IsAlive)
            {
#if DEBUG
                Debug.Log($"--- {RelatedUnitManager.UnitData.UnitName} IS DEAD.");
#endif
                //RelatedStateMachine.RemoveState(this); // Do not remove this state because it will break the state machine
                RelatedStateMachine.NextState(); // Do not confuse this with UnitTurns.NextState()
                return;
            }

            if (RelatedUnitManager.UnitStatusEffects.IsStunned)
            {
                Debug.Log($"{RelatedUnitManager.UnitData.UnitName} is STUNNED!");
                RelatedStateMachine.NextState();
                return;
            }
            #endregion
            RelatedUnitManager.UnitTurns.Begin(); // Do not confuse Begin with NextState
        }

        public override void Exit()
        {
            RelatedUnitManager.UnitTurnEnd();
        }

        public override void Process()
        {
        }
    }
}
