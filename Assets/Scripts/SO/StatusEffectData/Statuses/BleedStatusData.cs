namespace ProjectEON.SOData
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.CombatSystem.Units;

    [CreateAssetMenu(menuName = "StatusEffectData/Bleed")]
    public class BleedStatusData : StatusEffectData
    {
        public override StatusEffectBase CreateStatusEffect(UnitManager unitTarget, AttacksManager attacksManager)
        {
            return new BleedStatus(this, unitTarget, attacksManager);
        }
    }
}
