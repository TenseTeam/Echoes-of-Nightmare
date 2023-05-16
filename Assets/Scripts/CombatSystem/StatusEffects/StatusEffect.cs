namespace ProjectEON.CombatSystem.StatusEffects
{
    using UnityEngine;
    using System.Collections;
    using Extension.Patterns.StateMachine.Interfaces;
    using ProjectEON.SOData.Structures;
    using ProjectEON.CombatSystem.Units;

    public abstract class StatusEffect : IEventState
    {
        protected Unit UnitTarget;
        protected StatusEffectData Data;
        protected int AppliedTurns;

        public StatusEffect(StatusEffectData data, Unit unitTarget, int appliedTurns)
        {
            Data = data;
            UnitTarget = unitTarget;
            AppliedTurns = appliedTurns;
        }

        public abstract void Enter();
        public abstract void Process();
        public abstract void Exit();
    }
}