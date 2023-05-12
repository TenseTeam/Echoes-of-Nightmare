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
        
        [Header("Graphic")]
        public Sprite skillSprite;

        [Header("Statistics")]
        public uint rechargeTime;
        public uint power;
        [TextArea(3, 10)]
        public string description;

        [Header("Settings")]
        public SkillType skillType;
        public SkillTarget skillTarget;

        [Header("Effects")]
        public StatusEffect[] skillStatusEffects;
    }
}