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
            if (!RelatedUnitManager.Unit.IsAlive)
            {
#if DEBUG
                Debug.Log($"--- {RelatedUnitManager.UnitData.UnitName} IS DEAD.");
#endif
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
