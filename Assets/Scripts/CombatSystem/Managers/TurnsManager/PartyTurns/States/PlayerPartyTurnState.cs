namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class PlayerPartyTurnState : LinkedTurnState
    {
        private PlayerUnit _relatedUnit;
        private PlayerUnitTurns _unitTurns;

        public PlayerPartyTurnState(string name, TurnStateMachine relatedStateMachine, PlayerUnit relatedCombatant) : base(name, relatedStateMachine)
        {
            _relatedUnit = relatedCombatant;

            if (_relatedUnit.TryGetComponent(out PlayerUnitTurns unitTurns))
            {
                _unitTurns = unitTurns;
                _unitTurns.InitStates(relatedStateMachine, _relatedUnit);
            }
        }

        public override void Enter()
        {
            Debug.Log($"---ENTERING SUB STATEMACHINE OF {_relatedUnit.Data.UnitName} Unit.");
            _unitTurns.Begin();
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}
