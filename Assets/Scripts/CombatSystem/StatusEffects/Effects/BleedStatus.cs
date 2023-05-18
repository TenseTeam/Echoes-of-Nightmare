﻿namespace ProjectEON.CombatSystem.StatusEffects
{
    using UnityEngine;
    using System.Collections;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;

    public class BleedStatus : StatusEffect
    {
        private int _damagePerTurn;

        public BleedStatus(StatusEffectData data, Unit unitTarget, int appliedTurns, int damagePerTurn) : base(data, unitTarget, appliedTurns)
        {
            _damagePerTurn = damagePerTurn;
        }

        public override void Enter()
        {
            UnitTarget.TakeDamage(_damagePerTurn);
            AppliedTurns--;
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}