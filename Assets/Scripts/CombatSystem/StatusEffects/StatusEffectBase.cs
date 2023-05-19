namespace ProjectEON.CombatSystem.StatusEffects
{
    using UnityEngine;
    using System.Collections;
    using Extension.Patterns.StateMachine.Interfaces;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData.Structures.Enums;
    using ProjectEON.CombatSystem.Managers;

    public class StatusEffectBase : IEventState
    {
        protected UnitManager UnitManagerTarget;
        protected AttacksManager AttacksManager;

        public StatusEffectData Data { get; protected set; }
        public int AppliedTurns { get; protected set; }

        public StatusEffectBase(StatusEffectData data, UnitManager unitTarget, AttacksManager attacksManager)
        {
            Data = data;
            AttacksManager = attacksManager;
            UnitManagerTarget = unitTarget;
            AppliedTurns = Data.AppliedTurns;
        }

        /// <summary>
        /// On Apply status effect event.
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// On Process status effect event.
        /// </summary>
        public virtual void Process()
        {
            AppliedTurns--;
        }

        /// <summary>
        /// On Remove status effect event.
        /// </summary>
        public virtual void Exit() { }
    }
}