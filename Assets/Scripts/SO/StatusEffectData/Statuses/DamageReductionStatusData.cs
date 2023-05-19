namespace ProjectEON.SOData
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.CombatSystem.Units;

    [CreateAssetMenu(menuName = "StatusEffectData/DamageReductionBuff")]
    public class DamageReductionStatusData : StatusEffectData
    {
        public override StatusEffectBase CreateStatusEffect(UnitManager unitTarget, AttacksManager attacksManager)
        {
            return new ReceiveDamageReductionStatus(this, unitTarget, attacksManager);
        }
    }
}
