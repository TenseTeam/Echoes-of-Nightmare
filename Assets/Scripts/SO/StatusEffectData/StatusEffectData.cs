namespace ProjectEON.SOData
{
    using UnityEngine;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.CombatSystem.Units;

    public abstract class StatusEffectData : ScriptableObject
    {
        public Sprite EffectIcon;
        public int AppliedTurns;
    }
}
