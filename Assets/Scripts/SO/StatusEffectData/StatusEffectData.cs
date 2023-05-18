namespace ProjectEON.SOData
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.CombatSystem.Units;

    [CreateAssetMenu(menuName = "StatusEffectData")]
    public abstract class StatusEffectData : ScriptableObject
    {
        public Sprite EffectIcon;
        public int AppliedTurns;

        public abstract StatusEffectBase CreateStatusEffect(UnitManager unitTarget, AttacksManager attacksManager);
    }
}
