namespace ProjectEON.SOData
{
    using ProjectEON.SOData.Enums;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Combatant Data")]
    public class UnitData : ScriptableObject
    {
        [Header("Graphic")]
        public Sprite combatantSprite;

        [Header("Info")]
        public string unitName;

        [Header("Statistics")]
        public int hitPoints;

        [Header("Skill Set")]
        public List<SkillData> skills;
    }
}