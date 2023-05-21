namespace ProjectEON.SOData
{
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Generic.Serializable.Mathematics;
    using ProjectEON.SOData.Structures.Enums;
    using Unity.VisualScripting;

    [CreateAssetMenu(menuName = "Skills/SkillData")]
    public class SkillData : ScriptableObject
    {
        [Header("Statistics")]
        public Range<int> Power;
        [Range(0, 100)] public byte CriticalChance;

        [Header("Animation")]
        public AnimatorOverrideController SkillAnimatorOverrideController;

        [Header("Effects")]
        public List<StatusEffectData> SkillStatusEffects;

        [Header("Settings")]
        public SkillType SkillType;
        public SkillTarget SkillTarget;
        public bool IsAreaOfEffect;
    }
}