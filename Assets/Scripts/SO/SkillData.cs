namespace ProjectEON.SOData
{
    using UnityEngine;
    using Extension.Generic.Serializable.Mathematics;
    using ProjectEON.SOData.Structures;
    using ProjectEON.SOData.Structures.Enums;

    [CreateAssetMenu(menuName = "SkillData")]
    public class SkillData : ScriptableObject
    {
        [Header("Statistics")]
        public Range<int> Power;
        [Range(0, 100)] public byte CriticalChance;
        public int CriticalMultiplier;
        public int RechargeTime;

        [Header("Settings")]
        public SkillType SkillType;
        public SkillTarget SkillTarget;

        [Header("Effects")]
        public StatusEffect[] SkillStatusEffects;
    }
}