﻿namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections;
    using System.Collections.Generic;
    using ProjectEON.CombatSystem.Units;
    using Extension.Patterns.StateMachine;
    using UnityEngine;

    public class EnemyPartyTurnState : LinkedTurnState
    {
        private Unit _relatedUnit;
        private EnemyUnitTurns _unitTurns;

        public EnemyPartyTurnState(string name, TurnStateMachine relatedStateMachine, Unit relatedCombatant) : base(name, relatedStateMachine)
        {
            _relatedUnit = relatedCombatant;

            if (_relatedUnit.TryGetComponent(out EnemyUnitTurns unitTurns))
            {
                _unitTurns = unitTurns;
                _unitTurns.InitStates(relatedStateMachine, _relatedUnit);
            }
        }

        public override void Enter()
        {
            Debug.Log($"---ENTERING SUB STATEMACHINE OF {_relatedUnit.Data.UnitName} Unit.");

            if(!_relatedUnit.IsAlive)
            {
                Debug.Log("--- IS DEAD.");
                _unitTurns.Begin();
                return;
            }

            RelatedStateMachine.NextState();
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}
