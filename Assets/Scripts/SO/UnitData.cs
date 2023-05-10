namespace ProjectEON.SOData
{
    using ProjectEON.SOData.Enums;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Combatant Data")]
    public class UnitData : ScriptableObject
    {
        [Header("Graphic")]
        public Sprite combatantSprite;

        [Header("Info")]
        public string combatantName;

        [Header("Statistics")]
        public int hitPoints;

        [Header("Skill Set")]
        public SkillData[] skills;
    }
}