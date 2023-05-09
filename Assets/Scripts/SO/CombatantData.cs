namespace ProjectEON.SOData
{
    using ProjectEON.SOData.Enums;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Combatant Data")]
    public class CombatantData : ScriptableObject
    {
        [Header("Graphic")]
        public Sprite combatantSprite;

        [Header("Hit Points")]
        public int hitPoints;

        [Header("Skill-Set")]
        public SkillData[] skills;
    }
}