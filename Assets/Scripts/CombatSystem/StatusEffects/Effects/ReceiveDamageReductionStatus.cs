using ProjectEON.CombatSystem.Managers;
using ProjectEON.CombatSystem.Units;
using ProjectEON.SOData;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace ProjectEON.CombatSystem.StatusEffects
{
    public class ReceiveDamageReductionStatus : StatusEffectBase
    {
        public ReceiveDamageReductionStatus(StatusEffectData data, UnitManager unitTarget, AttacksManager attacksManager) : base(data, unitTarget, attacksManager)
        {
        }

        public override void Enter()
        {
            UnitManagerTarget.UnitStatusEffects.ApplyDamageReduction(AttacksManager.ReceiveDamageReduction);
        }

        public override void Exit()
        {
            UnitManagerTarget.UnitStatusEffects.RemoveDamageReduction();
        }

        public override void Process()
        {
            base.Process();
        }
    }
}