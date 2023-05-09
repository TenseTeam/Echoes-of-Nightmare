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

        public Sprite skillSprite;
        public SkillType skillType;
        public SkillTarget skillTarget;
        public StatusEffect[] skillStatusEffects;
        public int power;
    }
}