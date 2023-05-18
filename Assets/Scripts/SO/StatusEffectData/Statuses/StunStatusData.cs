namespace ProjectEON.SOData
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.CombatSystem.Units;

    [CreateAssetMenu(menuName = "StatusEffectData/Stun")]
    public class StunStatusData : StatusEffectData
    {
        public override StatusEffectBase CreateStatusEffect(UnitManager unitTarget, AttacksManager attacksManager)
        {
            return new StunStatus(this, unitTarget, attacksManager);
        }
    }
}
