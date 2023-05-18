namespace ProjectEON.CombatSystem.StatusEffects
{
    using UnityEngine;
    using System.Collections;
    using ProjectEON.SOData.Structures;
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
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
            UnitTarget.TakeDamage(_damagePerTurn);
            AppliedTurns--;
        }
    }
}