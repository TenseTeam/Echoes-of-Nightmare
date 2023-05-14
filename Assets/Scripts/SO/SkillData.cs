namespace ProjectEON.SOData
{
    using ProjectEON.SOData.Enums;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Skill Data")]
    public class SkillData : ScriptableObject
    {
        [System.Serializable]
        public struct StatusEffect
        {
            public SkillStatusEffect statusEffect;
            public int turns;
        }

        [Header("Info")]
        public string SkillName;
        [TextArea(3, 10)]
        public string Description;

        [Header("Statistics")]
        public uint RechargeTime;
        public uint Power;

        [Header("Settings")]
        public SkillType SkillType;
        public SkillTarget SkillTarget;

        [Header("Effects")]
        public StatusEffect[] SkillStatusEffects;
    }
}