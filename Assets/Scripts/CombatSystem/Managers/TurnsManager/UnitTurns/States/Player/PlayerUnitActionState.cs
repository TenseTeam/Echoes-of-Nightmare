namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine;

    public class PlayerUnitActionState : UnitState<PlayerUnitManager>
    {
        public PlayerUnitActionState(string name, TurnStateMachine relatedStateMachine, PlayerUnitManager unit) : base(name, relatedStateMachine, unit) // I will pass here the "cards drawer".
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering Player Action");
            // TO DO -> Here goes the animation trigger
            UnitManager.UnitHand.SetActiveHand(false);
            RelatedStateMachine.NextStateIn(2f);
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}