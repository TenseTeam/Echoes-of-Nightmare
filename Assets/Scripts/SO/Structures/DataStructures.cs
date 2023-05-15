namespace ProjectEON.SOData.Structures
{
    using ProjectEON.SOData.Structures.Enums;
    using UnityEngine;

    [System.Serializable]
    public class StatusEffect
    {
        public StatusEffectType EffectType;
        public Sprite EffectIcon;
        public uint Turns;
    }
}
