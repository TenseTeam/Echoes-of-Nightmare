namespace ProjectEON.SOData.Structures
{
    using ProjectEON.SOData.Structures.Enums;
    using UnityEngine;

    [System.Serializable]
    public struct StatusEffectData
    {
        public StatusEffectType EffectType;
        public Sprite EffectIcon;
        public uint AppliedTurns;
    }
}
