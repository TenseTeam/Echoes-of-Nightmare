namespace ProjectEON.SOData
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.CombatSystem.Units;

    [CreateAssetMenu(menuName = "StatusEffectData/DamageDownDebuff")]
    public class DamageDownStatusData : StatusEffectData
    {
        public override StatusEffectBase CreateStatusEffect(UnitManager unitTarget, AttacksManager attacksManager)
        {
            return new DamageDownStatus(this, unitTarget, attacksManager);
        }
    }
}
