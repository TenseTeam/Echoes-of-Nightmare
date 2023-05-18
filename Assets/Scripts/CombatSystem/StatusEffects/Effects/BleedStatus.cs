namespace ProjectEON.CombatSystem.StatusEffects
{
    using UnityEngine;
    using System.Collections;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData.Structures.Enums;
    using ProjectEON.CombatSystem.Managers;

    public class BleedStatus : StatusEffectBase
    {
        public BleedStatus(StatusEffectData data, UnitManager unitTarget, AttacksManager attacksManager) : base(data, unitTarget, attacksManager)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            // No needs to add a method for removing bleed since it's just only a TakeDamage method in the Process
        }

        public override void Process()
        {
            base.Process();
            UnitManagerTarget.UnitStatusEffects.ApplyBleedDamage(AttacksManager.BleedDamage);;
        }
    }
}