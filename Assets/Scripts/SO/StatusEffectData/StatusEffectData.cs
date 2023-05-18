namespace ProjectEON.SOData
{
    using UnityEngine;

    //[CreateAssetMenu(menuName = "Status Effect Data")]
    public class StatusEffectData : ScriptableObject
    {
        //public StatusEffectType EffectType;
        public Sprite EffectIcon;
        [Min(1)]
        public uint AppliedTurns;
    }
}
