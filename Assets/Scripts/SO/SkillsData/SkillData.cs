namespace ProjectEON.SOData
{
    using UnityEngine;
    using System.Collections.Generic;
    using Extension.Generic.Serializable.Mathematics;
    using ProjectEON.SOData.Structures.Enums;

    [CreateAssetMenu(menuName = "Combat/Skills/Generic Skill")]
    public class SkillData : ScriptableObject
    {
        [Header("Statistics")]
        public Range<int> Power;
        [Range(0, 100)] public byte CriticalChance;

        [Header("Animation")]
        public AnimatorOverrideController SkillAnimatorOverrideController;

        [Header("Audio")]
        public AudioClip AttackClip;

        [Header("Effects")]
        public List<StatusEffectData> SkillStatusEffects;

        [Header("Settings")]
        public SkillType SkillType;
        public SkillTarget SkillTarget;
        public bool IsAreaOfEffect;
    }
}