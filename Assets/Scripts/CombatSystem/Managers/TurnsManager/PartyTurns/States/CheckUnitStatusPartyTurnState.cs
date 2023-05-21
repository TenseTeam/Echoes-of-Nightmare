namespace ProjectEON.CombatSystem.StateMachines
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;

    public class CheckUnitStatusPartyTurnState : PartyTurnState
    {
        public CheckUnitStatusPartyTurnState(string name, TurnStateMachine relatedStateMachine, UnitManager relatedUnitManager) : base(name, relatedStateMachine, relatedUnitManager)
        {
        }

        public override void Enter()
        {
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
#if DEBUG
                Debug.Log($"{RelatedUnitManager.UnitData.UnitName} is STUNNED!");
#endif
                RelatedStateMachine.NextState();
                return;
            }

            RelatedStateMachine.NextStateIn(1f);
        }
    }
}
