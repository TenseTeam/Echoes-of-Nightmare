namespace ProjectEON.SOData
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.CombatSystem.Units;

    [CreateAssetMenu(menuName = "StatusEffectData/Fear")]
    public class FearStatusData : StatusEffectData
    {
        public override StatusEffectBase CreateStatusEffect(UnitManager unitTarget, AttacksManager attacksManager)
        {
            return new FearStatus(this, unitTarget, attacksManager);
        }
    }
}
