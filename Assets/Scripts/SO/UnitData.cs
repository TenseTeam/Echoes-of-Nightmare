namespace ProjectEON.SOData
{
    using ProjectEON.SOData.Enums;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Unit Data")]
    public class UnitData : ScriptableObject
    {
        [Header("Graphic")]
        public Sprite UnitSprite;

        [Header("Info")]
        public string UnitName;

        [Header("Statistics")]
        public int HitPoints;

        [Header("Skill Set")]
        public List<SkillData> Skills;

        //public AnimationClip anim; struct for animation
    }
}